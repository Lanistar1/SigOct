using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    public class ChangePasswordRequest
    {
        public ChangePasswordRequest(string oldPass, string newPass)
        {
            oldPassword = oldPass;
            newPassword = newPass;

        }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }

    }
}
