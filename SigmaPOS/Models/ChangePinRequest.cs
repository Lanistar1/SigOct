using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    class ChangePinRequest
    {
        public ChangePinRequest(string past, string current)
        {
            oldPin = past;
            newPin = current;

        }
        public string oldPin { get; set; }
        public string newPin { get; set; }

    }
}
