using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    public class ResetPinRequestModel
    {
        public ResetPinRequestModel(string oldUserPin, string newUserPin)
        {
            oldPin = oldUserPin;
            newPin = newUserPin;

        }
        public string oldPin { get; set; }
        public string newPin { get; set; }
    }
}
