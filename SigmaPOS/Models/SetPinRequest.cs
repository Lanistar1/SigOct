using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    public class SetPinRequest
    {
        public SetPinRequest(string newPin)
        {
            pin = newPin;

        }
        public string pin { get; set; }

    }
}
