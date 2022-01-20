using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model
{
    public class Address : ValueObject
    {
        public int AdressId { get; private set; }
        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StreetAddress;
            yield return City;
            yield return Country;
        }

        public Address(int adressId, string streetAddress, string city, string country)
        {
            AdressId = adressId;
            StreetAddress = streetAddress;
            City = city;
            Country = country;
        }

        public Address()
        {
        }
    }
}
