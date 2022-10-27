using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    public class LoginRequest
    {
        public LoginRequest(string pass, string user, string merId)
        {
            password = pass;
            username = user;
            merchantID = merId;
        }
        public string password { get; set; }
        public string username { get; set; }
        public string merchantID { get; set; }
    }
}
