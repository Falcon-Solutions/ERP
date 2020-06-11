using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Entity.Address
{
    public class AddressDetails
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Tehsil { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pin { get; set; }
        public int PinMasterId { get; set; }
    }

    public class AddUpdateAddress
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
        public int PinCodeId { get; set; }
    }

    public class PostalCodeMaster
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Tehsil { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pin { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int refStateId { get; set; }
    }

    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int refCountryId { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
