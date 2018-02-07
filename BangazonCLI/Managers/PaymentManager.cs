//Paul Ellis
//Payment Manager

using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Models;

namespace BangazonCLI.Managers
{
    public class PaymentManager
    {
        //List to hold all of the Payments
        private List<Payment> _TestPaymentList = new List<Payment>();

        //Adds a Payment to the list
        public void Add(Payment Payment)
        {
            _TestPaymentList.Add(Payment);
        }

        // return all of the Payments
        public List<Payment> GetAllPayments()
        {
            return _TestPaymentList;
        }

        //Given a customer id int, this method will return all payments associated with that customer in a list
        public List<Payment> GetCustomerPayments(int CustomerId)
        {
            return _TestPaymentList.Where(p => p.CustomerId == CustomerId).ToList();
        }

    }
}