using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark.Common
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class AddressDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Credit { get; set; }
        public Address Address { get; set; }
        public Address HomeAddress { get; set; }
        public Address[] Addresses { get; set; }
        public List<Address> WorkAddresses { get; set; }
    }

    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public AddressDTO HomeAddress { get; set; }
        public AddressDTO[] Addresses { get; set; }
        public List<AddressDTO> WorkAddresses { get; set; }
        public string AddressCity { get; set; }
    }

    public class _Base
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }

        public int Height { get; set; }
        public int Wight { get; set; }

        public string Color { get; set; }

    }
    public class B : _Base
    {
    }

    public class C : _Base
    {
    }

    public class D : _Base
    {
    }

    public class E : _Base
    {
    }

    public class F : _Base
    {
    }

    public class BDto : _Base
    {
    }

    public class CDto : _Base
    {
    }
    public class DDto : _Base
    {
    }
    public class EDto : _Base
    {
    }
    public class FDto : _Base
    {
    }

    public class _DeepBase
    {
        public B GetB { get; set; }
        public C GetC { get; set; }

        public D GetD { get; set; }
        public E GetE { get; set; }
        public F GetF { get; set; }
        public _DeepBase()
        {
            GetB = new B();
            GetC = new C();
            GetD = new D();
            GetE = new E();
            GetF = new F();
        }

    }

    public class DeepBCDEF : _DeepBase
    {
        public DeepBCDEF() : base() { }
    }

    public class DeepCDE : _DeepBase
    {
        public DeepCDE() : base()
        {
            GetB = null;
            GetF = null;
        }

    }
}
