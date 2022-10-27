using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class UserCardDetails
    {
        public string cardPan { get; set; }
        public string cardType { get; set; }
        public string cardExpiry { get; set; }
    }

    public class InterswitchDetails
    {
        public string interswitchRef { get; set; }
        public string interswitchResponseCode { get; set; }
        public string interswitchResponseMessage { get; set; }
    }

    public class CompleteTransactionModel
    {
        public string transactionId { get; set; }
        public string status { get; set; }
        public InterswitchDetails interswitchDetails { get; set; }
        public UserCardDetails cardDetails { get; set; }
    }


}
