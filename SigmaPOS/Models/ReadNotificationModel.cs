using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ReadNotificationData
    {
        public string id { get; set; }
        public bool isRead { get; set; }
        public string dateRead { get; set; }
    }

    public class ReadNotificationModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public ReadNotificationData data { get; set; }
    }


}
