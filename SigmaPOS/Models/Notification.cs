using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class NotificationData
    {
        public string id { get; set; }
        public string recepient { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public string dateCreated { get; set; }
        public bool isRead { get; set; }
        public object dateRead { get; set; }
    }

    public class NotificationModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<NotificationData> data { get; set; }
    }


}
