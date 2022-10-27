using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Data
    {
    }

    public class SetPinResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }


}
