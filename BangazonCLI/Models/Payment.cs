//Author: Paul Ellis; Purpose: Payment class and assocaited methods


using System;

namespace BangazonCLI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string PaymentType { get; set; }
        public string AccountNumber { get; set; }


        //Constructor Method for Payment Type
        //Accepts arguments corresponding to the values defined above in the Payment class
        public Payment(int id, int customer, string type, string num)
        {
            Id = id;
            PaymentType = type;
            AccountNumber = num;
            CustomerId = customer;
        }
    }
}