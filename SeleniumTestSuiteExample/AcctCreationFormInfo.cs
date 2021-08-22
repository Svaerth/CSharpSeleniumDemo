using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTestSuiteExample
{
    class AcctCreationFormInfo
    {
        public string Email { get; set; }
        public string PersonalInfo_firstName { get; set; }
        public string PersonalInfo_lastName { get; set; }
        public string Password { get; set; }
        public string Addr_firstName { get; set; }
        public string Addr_lastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string MobilePhone { get; set; }
        public string Alias { get; set; }

        public static AcctCreationFormInfo CreateWithRandomEmail()
        {
            var info = new AcctCreationFormInfo();
            info.Email = RandomStringGenerator.Generate(10) + "@gmail.com";
            info.PersonalInfo_firstName = "test";
            info.PersonalInfo_lastName = "user";
            info.Password = "Password123";
            info.Addr_firstName = info.PersonalInfo_firstName;
            info.Addr_lastName = info.PersonalInfo_lastName;
            info.AddressLine1 = "123 Nowhere blvd";
            info.AddressLine2 = "Apt 77";
            info.City = "Some Place";
            info.State = "Alabama";
            info.ZipCode = "77777";
            info.Country = "United States";
            info.MobilePhone = "555-5555";
            info.Alias = "test alias";
            return info;
        }
    }
}
