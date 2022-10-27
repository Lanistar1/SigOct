using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    class ForgetPasswordRequest
    {
        public ForgetPasswordRequest(string number)
        {
            phoneNumber = number;

        }
        public string phoneNumber { get; set; }
    }
}
