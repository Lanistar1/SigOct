using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    public class ResetPasswordRequest
    {
        public ResetPasswordRequest(string pass)
        {
            password = pass;
            
        }
        public string password { get; set; }
       
    }
}
