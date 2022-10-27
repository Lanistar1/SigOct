using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class TerminalData
    {
        public string id { get; set; }
        public string createdAt { get; set; }
        public string macAddress { get; set; }
        public string name { get; set; }
        public string serialNumber { get; set; }
        public string status { get; set; }
        public string condition { get; set; }
        public string arrivedAt { get; set; }
        public string modelNumber { get; set; }
        public string deviceKey { get; set; }
        public List<string> features { get; set; }
    }

    public class TerminalModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public TerminalData data { get; set; }
    }


}
