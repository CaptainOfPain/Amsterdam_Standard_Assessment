using System.Collections.Generic;
using ChannelEngineAssessmentShared.Extensions;

namespace ChannelEngineAssessmentDomain
{
    public struct Address
    {
        public string Line1 { get; private set; }
        public string Line2 { get; private set; }
        public string Line3 { get; private set; }
        public Gender Gender { get; private set; }
        public string CompanyName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string StreetName { get; private set; }
        public string HouseNr { get; private set; }
        public string HouseNrAddition { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string Region { get; private set; }
        public string CountryIso { get; private set; }
        public string Original { get; private set; }

        public Address(string line1, string line2, string line3, Gender gender, string companyName, string firstName, string lastName, string streetName, string houseNr, string houseNrAddition, string zipCode, string city, string region, string countryIso, string original)
        {
            Line1 = line1;
            Line2 = line2;
            Line3 = line3;
            Gender = gender;
            CompanyName = companyName.ValidateStringLength(50, nameof(companyName));
            FirstName = firstName.ValidateStringLength(50, nameof(firstName));
            LastName = lastName.ValidateStringLength(50, nameof(lastName));
            StreetName = streetName.ValidateStringLength(50, nameof(streetName));
            HouseNr = houseNr.ValidateStringLength(50, nameof(houseNr));
            HouseNrAddition = houseNrAddition.ValidateStringLength(50, nameof(houseNrAddition));
            ZipCode = zipCode;
            City = city.ValidateStringLength(50, nameof(city));
            Region = region.ValidateStringLength(50, nameof(region));
            CountryIso = countryIso.ValidateStringLength(2, nameof(countryIso));
            Original = original.ValidateStringLength(256, nameof(original));
        }
    }
}
