using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class TransactionMetric
    {
        public int totalCredits { get; set; }
        public int totalDebits { get; set; }
        public int totalTransactionCount { get; set; }
        public List<object> transactionData { get; set; }
    }


}
