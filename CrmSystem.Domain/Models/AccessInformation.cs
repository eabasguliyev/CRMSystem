using System;

namespace CrmSystem.Domain.Models
{
    public class AddressInformation:DomainObject, ICloneable
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public void Update(AddressInformation userAddressInfo)
        {
            Street = userAddressInfo.Street;
            City = userAddressInfo.City;
            State = userAddressInfo.State;
            ZipCode = userAddressInfo.ZipCode;
            Country = userAddressInfo.Country;
        }
    }
}