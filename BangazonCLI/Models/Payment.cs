using System;

namespace BangazonCLI.Models
{
    public class Payment
    {
        public int PaymentId {get; set;}
        public string PaymentType {get; set;}
        public string AccountNumber {get; set;}
        public int CustomerId {get; set;}

        public Payment(int id, string type, string num, int customer)
        {
            PaymentId = id;
            PaymentType = type;
            AccountNumber = num;
            CustomerId = customer;
        }
    }
}