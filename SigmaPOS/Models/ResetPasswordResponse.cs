using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class UserHomeAddress
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string userIdentityType { get; set; }
        public string userIdentityNumber { get; set; }
    }

    public class UserDatas
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string dob { get; set; }
        public UserHomeAddress address { get; set; }
        public string email { get; set; }
        public string userIdentityType { get; set; }
        public string userIdentityNumber { get; set; }
        public string status { get; set; }
        public UserNextOfKins nextOfKin { get; set; }
        public string token { get; set; }
        public bool isPasswordChangeRequired { get; set; }
    }

    public class UserNextOfKins
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string relationship { get; set; }
        public Address address { get; set; }
    }

    public class ResetPasswordModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public UserDatas data { get; set; }
    }


}
