using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Beneficiary
    {
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }

    public class BeneficiaryTerminal
    {
        public string teminalName { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string accountType { get; set; }
        public string bankCode { get; set; }
        public string bankId { get; set; }
        public string bankName { get; set; }
        public string billerName { get; set; }
        public string billerId { get; set; }
        public string categoryId { get; set; }
        public string categoryName { get; set; }
        public string paymentCode { get; set; }
        public string paymentItemName { get; set; }
        public string customerId { get; set; }
    }

    public class CardDetails
    {
        public string cardPan { get; set; }
        public string cardType { get; set; }
        public string cardExpiry { get; set; }
    }

    public class Facilitator
    {
        public string id { get; set; }
        public string phone { get; set; }
        public string pin { get; set; }
        public string email { get; set; }
    }

    public class InitiateTransactionModel
    {
        public int amount { get; set; }
        public string transactionType { get; set; }
        public Facilitator facilitator { get; set; }
        public Beneficiary beneficiary { get; set; }
        public BeneficiaryTerminal beneficiaryTerminal { get; set; }
        public CardDetails cardDetails { get; set; }
        public string narration { get; set; }
        public bool isChargeIncluded { get; set; }
    }


}
