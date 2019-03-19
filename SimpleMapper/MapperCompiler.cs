using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using EntityMapper.Templates;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.Loader;
using System.Text;

namespace EntityMapper
{
    public class MapperCompiler
    {
        static Dictionary<string, string> _assemblies = null;
        private static string _mapableTemplateSingleClass = null;
        private static string _mapableTemplateMultipleClasses = null;
        internal static HashSet<IMapInfo> _maps;
        public static string MapableTemplateSingleClass
        {
            get
            {
                if (_mapableTemplateSingleClass == null)
                    _mapableTemplateSingleClass = LoadMapableTemplateSingleClass();

                return _mapableTemplateSingleClass;

            }
        }

        public static string MapableTemplateMultipleClasses
        {
            get
            {
                if (_mapableTemplateMultipleClasses == null)
                    _mapableTemplateMultipleClasses = LoadMapableTemplateMultipleClasses();

                return _mapableTemplateMultipleClasses;

            }
        }

        internal static void GenerateDynamicClass(IMapInfo mappingToGenerateSourceFor, bool deepCopy = false)
        {


            StringBuilder sourceCode = new StringBuilder();
            sourceCode.Append(MapableTemplateSingleClass);

            //Type tSrc = mappingToGenerateSourceFor.Value.SourceType;
            //Type tDest = mappingToGenerateSourceFor.Value.DestinationType;

            Type tSrc = mappingToGenerateSourceFor.SourceType;
            Type tDest = mappingToGenerateSourceFor.DestinationType;
            sourceCode = ReplaceTemplateKey(sourceCode, TemplateKeys.SourceNamespace, tSrc.Namespace);
            sourceCode = ReplaceTemplateKey(sourceCode, TemplateKeys.SourceName, tSrc.Name);
            sourceCode = ReplaceTemplateKey(sourceCode, TemplateKeys.TDestination, tDest.Name);
            sourceCode = ReplaceTemplateMappingProperties(sourceCode, TemplateKeys.DestinationPropertyMapping, tSrc, tDest, "destination", "source", deepCopy);
            sourceCode = ReplaceTemplateMappingProperties(sourceCode, TemplateKeys.DestinationPropertyMappingDeep, tSrc, tDest, "destination", "source", true);
            sourceCode = ReplaceTemplateKey(sourceCode, TemplateKeys.DestinationPropertyMappingList, ReplaceTemplateKey("destination.Add(ConvertToInternal(source, new TDestination()));", TemplateKeys.TDestination, tDest.Name));
            mappingToGenerateSourceFor.SourceCodeTSource  = sourceCode.ToString();
        }

        internal static string GenerateAllDynamicClasses(HashSet<IMapInfo> maps)
        {


            StringBuilder sourceCode = new StringBuilder();
            sourceCode.AppendLine(MapableTemplateMultipleClasses);

            StringBuilder classes = new StringBuilder();
            StringBuilder destinationUsingStatements = new StringBuilder();
            List<string> namespaces = new List<string>();
            foreach (var map in maps)
            {
                var usingStatemenet = $"using {map.DestinationNamespace};";
                if (namespaces.Contains(usingStatemenet) == false)
                {
                    namespaces.Add(usingStatemenet);
                    destinationUsingStatements.AppendLine(usingStatemenet);
                }
                classes.AppendLine(map.SourceCodeTSource);
            }
            sourceCode = ReplaceTemplateKey(sourceCode, TemplateKeys.UsingNamespaces, destinationUsingStatements.ToString());
            sourceCode = ReplaceTemplateKey(sourceCode, TemplateKeys.Classes, classes.ToString());
            return sourceCode.ToString();
        }

        private static StringBuilder ReplaceTemplateKey(StringBuilder source, string templateKey, string value)
        {
            return source.Replace(templateKey, value);
        }

        private static string ReplaceTemplateKey(string source, string templateKey, string value)
        {
            return source.Replace(templateKey, value);
        }

        private static StringBuilder ReplaceTemplateMappingProperties(StringBuilder source, string templateKey, Type src, Type dest, string destinationName = "destination", string sourceName = "this", bool deepCopy = false)
        {
            StringBuilder temp = new StringBuilder();
            var destProps = dest.GetProperties();
            foreach (var srcProp in src.GetProperties().Where(p => p.GetMethod.IsPublic && p.SetMethod.IsPublic))
            {
                var destProp = destProps.Where(p => p.Name == srcProp.Name && p.GetMethod.IsPublic && p.SetMethod.IsPublic).FirstOrDefault();
                if (destProp != null)
                {
                    //this need to be configurable -> if true -> objDest.ObjProp = objSource.ObjProp; if false -> objDest.ObjProp = EntityMapper.Mapper.Current.Map<objSource.ObjPropType, objDest.ObjPropType>(source);
                    if (deepCopy == false || (destProp.PropertyType.IsPrimitive == true || destProp.PropertyType.Name == "String"))
                    {
                        temp.AppendLine($"destination.{destProp.Name} = {sourceName}.{srcProp.Name};");
                    }
                    else if(false == (destProp.PropertyType.IsPrimitive == true || destProp.PropertyType.Name == "String"))//deep copy is true and it's not primitive type
                    {
                        //ReplaceTemplateMappingProperties(source, srcProp.PropertyType, destProp.PropertyType,
                        //    $"{destinationName}.{destProp.Name}", $"{sourceName}.{srcProp.Name}");

                        temp.AppendLine($"destination.{destProp.Name} = EntityMapper.Mapper.Current.Map<{srcProp.PropertyType.Name}, {destProp.PropertyType.Name}>({sourceName}.{srcProp.Name});");
                    }
                }
            }

            //var propMappings = GenerateMapSourceCode(src, dest, destinationName, sourceName);
            //return source.Replace(TemplateKeys.DestinationPropertyMapping, propMappings);
            return source.Replace(templateKey, temp.ToString());
        }

        /// <summary>
        /// Build code of property mapping lines for the whole object tree.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        /// <param name="destinationName"></param>
        /// <param name="sourceName"></param>
        /// <returns></returns>
        static string GenerateMapSourceCode(Type src, Type dest, string destinationName = "destination", string sourceName = "this")
        {
            StringBuilder result = new StringBuilder();
            var destProps = dest.GetProperties();
            foreach (var srcProp in src.GetProperties().Where(p => p.GetMethod.IsPublic && p.SetMethod.IsPublic))
            {
                var destProp = destProps.Where(p => p.Name == srcProp.Name && p.GetMethod.IsPublic && p.SetMethod.IsPublic).FirstOrDefault();
                if (destProp != null)
                {
                    //this need to be configurable -> if true -> objDest.ObjProp = objSource.ObjProp; if false -> objDest.ObjProp = EntityMapper.Mapper.Current.Map<objSource.ObjPropType, objDest.ObjPropType>(source);
                    if ((destProp.PropertyType.IsPrimitive == true || destProp.PropertyType.Name == "String"))
                    {
                        result.AppendLine($"{destinationName}.{destProp.Name} = {sourceName}.{srcProp.Name};");
                    }
                    else
                    {
                        result.AppendLine(GenerateMapSourceCode(srcProp.PropertyType, destProp.PropertyType,
                            $"{destinationName}.{destProp.Name}?", $"{sourceName}.{srcProp.Name}?"));
                    }
                }
            }
            return result.ToString();
        }

        //private static StringBuilder ReplaceTemplateMappingListProperties(StringBuilder source, Type src, Type dest)
        //{
        //    StringBuilder temp = new StringBuilder();
        //    var destProps = dest.GetProperties();
        //    foreach (var srcProp in src.GetProperties().Where(p => p.GetMethod.IsPublic && p.SetMethod.IsPublic))
        //    {
        //        var destProp = destProps.Where(p => p.Name == srcProp.Name && p.GetMethod.IsPublic && p.SetMethod.IsPublic).FirstOrDefault();
        //        if (destProp != null)
        //        {
        //            if (destProp.PropertyType.IsPrimitive == true || destProp.PropertyType.Name == "String")
        //            {
        //                temp.AppendLine($"destination.{destProp.Name} = {sourceName}.{srcProp.Name};");
        //            }
        //            else
        //            {
        //                temp.AppendLine($"destination.{destProp.Name} = EntityMapper.Mapper.Current.Map<{srcProp.PropertyType.Name}, {destProp.PropertyType.Name}>({sourceName}.{srcProp.Name});");
        //            }
        //        }
        //    }
        //    return source.Replace(TemplateKeys.DestinationPropertyMapping, temp.ToString());
        //}

        private static void LoadNeededAssemblies()
        {
            ConcurrentBag<string> test = new ConcurrentBag<string>() { "" };
            System.Threading.Tasks.Parallel.ForEach(test, t => { });
        }

        private static string LoadMapableTemplateMultipleClasses()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Where(r => r.Contains("MapableTemplateMultipleClasses.cs")).FirstOrDefault();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static string LoadMapableTemplateSingleClass()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Where(r => r.Contains("MapableTemplateSingleClass.cs")).FirstOrDefault();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        internal static void Compile(HashSet<IMapInfo> maps, string assemblyName = "EntityMapper.Dynamic.Mappers.dll")
        {
            LoadNeededAssemblies();
            string sourceCode = GenerateAllDynamicClasses(maps);
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            //string assemblyName = Path.GetFileName("EntityMapper.Dynamic.Mappers.dll");
            BuildReferences();

            List<MetadataReference> references = new List<MetadataReference>();
            foreach (var kvp in _assemblies)
            {
                if (kvp.Key.Split('.').Count() == 2) continue;
                if (kvp.Key.EndsWith(".exe")) continue;
                if (kvp.Key.Contains("kernel")) continue;
                if (kvp.Key.Contains("windows.storage")) continue;
                references.Add(MetadataReference.CreateFromFile(kvp.Value));
            }
            references.Add(MetadataReference.CreateFromFile(_assemblies[System.Reflection.Assembly.GetEntryAssembly().ManifestModule.Name]));
            references.Add(MetadataReference.CreateFromFile(_assemblies[System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name]));//EntityMapper.dll
            references.Add(MetadataReference.CreateFromFile(@"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.2.0\System.Threading.Tasks.Parallel.dll"));
            references.Add(MetadataReference.CreateFromFile(@"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.2.0\netstandard.dll"));    
            //references.Add(MetadataReference.CreateFromFile(_assemblies["System.Treading.Task.dll"]));

            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: new[] { syntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, false, null, null, null, null, OptimizationLevel.Release));


            using (var ms = new MemoryStream())
            {
                EmitResult result = compilation.Emit(ms);

                if (!result.Success)
                {
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (Diagnostic diagnostic in failures)
                    {
                        System.Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
                    }
                }
                else
                {
                    //if (false == File.Exists(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + @"\" + assemblyName))
                    //{
                    //    ms.Seek(0, SeekOrigin.Begin);
                    //    File.WriteAllBytes(assemblyName, ms.ToArray());
                    //}
                    //else
                    //{
                    //    try
                    //    {
                    //        File.Delete(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + @"\" + assemblyName);
                    //        ms.Seek(0, SeekOrigin.Begin);
                    //        File.WriteAllBytes(assemblyName, ms.ToArray());
                    //    }
                    //    catch
                    //    {

                    //    }
                    //}
                    ms.Seek(0, SeekOrigin.Begin);
                    var myAssembly = System.Reflection.Assembly.Load(ms.ToArray());
                    //var myAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + @"\" + assemblyName);
                    
                    try
                    {
                        foreach (var map in maps)
                        {
                            var type = myAssembly.GetType($"EntityMapper.Dynamic.Mappers.{map.SourceType.Name}_{map.DestinationType.Name}");
                            IMappable instance = Activator.CreateInstance(type) as IMappable;
                            map.Instance = instance;
                            map.Mapper = map.SourceType;
                        }
                    }
                    catch
                    {
                    }
                    
                    
                }
            }
        }

        private static void BuildReferences()
        {
            if (_assemblies == null)
            {
                _assemblies = new Dictionary<string, string>();
                foreach (var m in Process.GetCurrentProcess().Modules.ToDynamicList())
                {
                    if (m.FileName.ToLower().Contains("system32")) continue;
                    _assemblies.Add(m.ModuleName, m.FileName);
                }
            }
        }
    }
}
