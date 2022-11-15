using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Agent
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string walletId { get; set; }
    }

    public class BeneficiaryDetail
    {
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }

    public class BeneficiaryTerminalDetails
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

    public class AgentBusiness
    {
        public string id { get; set; }
        public string walletId { get; set; }
        public bool isVerify { get; set; }
        public string name { get; set; }
        public string registrationNumberType { get; set; }
        public string registrationNumber { get; set; }
        public string memorandomOfAssociationURL { get; set; }
        public string email { get; set; }
    }

    public class CardHolderDetails
    {
        public string cardType { get; set; }
    }

    public class AgentTransaction
    {
        public string id { get; set; }
        public string flow { get; set; }
        public int amount { get; set; }
        public int charge { get; set; }
        public string transactionType { get; set; }
        public string status { get; set; }
        public TerminalDetails terminalDetails { get; set; }
        public PerformedBy performedBy { get; set; }
        public CardHolderDetails cardHolderDetails { get; set; }
        public Interswitch interswitchDetails { get; set; }
        public BeneficiaryDetail beneficiary { get; set; }
        public BeneficiaryTerminalDetails beneficiaryTerminal { get; set; }
        public string narration { get; set; }
        public bool isChargeIncluded { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Interswitch
    {
        public string interswitchRef { get; set; }
    }

    public class Location
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
    }

    public class Merchant
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string status { get; set; }
        public AgentBusiness business { get; set; }
    }

    public class PerformedBy
    {
        public Agent agent { get; set; }
        public Merchant merchant { get; set; }
    }

    public class AgentTransactionModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<AgentTransaction> data { get; set; }
    }

    public class TerminalDetails
    {
        public string id { get; set; }
        public string createdAt { get; set; }
        public string macAddress { get; set; }
        public string name { get; set; }
        public string serialNumber { get; set; }
        public string status { get; set; }
        public string condition { get; set; }
        public string arrivedAt { get; set; }
        public Location location { get; set; }
    }


}
