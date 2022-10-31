using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class wallet
    {
        public string amount { get; set; }
        public string card { get; set; }
        public string date { get; set; }
        public string day { get; set; }
        public string details { get; set; }
        public string name { get; set; }
        public string time { get; set; }
        public string type { get; set; }
    }

    public class Cool
    {
        public double test { get; set; }
        public string yep { get; set; }
    }

    public class WalletData
    {
        public string walletId { get; set; }
        public string walletName { get; set; }
        public string customerReference { get; set; }
        public string identifier { get; set; }
        public int availableBalance { get; set; }
        public int ledgerBalance { get; set; }
        public string walletType { get; set; }
        public string currency { get; set; }
        public DateTime createdAt { get; set; }
        public string createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public string updatedBy { get; set; }
        public string tenant { get; set; }
        public string holderId { get; set; }
        public string holderName { get; set; }
        public Metadata metadata { get; set; }
        public wallet wallet { get; set; }
        public bool isSelected { get; set; }
    }

    public class Metadata
    {
        public string Collest { get; set; }
        public Cool cool { get; set; }
    }

    public class WalletModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public WalletData data { get; set; }
    }


}
