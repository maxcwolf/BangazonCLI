using System.Collections.Generic;
using BangazonCLI.Models;
using System.Linq;

namespace BangazonCLI.Managers
{
    public class CustomerManager
    {
        private List<Customer> _customerTable = new List<Customer>();

        public void Add(Customer custy)
        {
            _customerTable.Add(custy);
        }

        public List<Customer> GetAllCustomers ()
        {
            return _customerTable;
        }

        public Customer GetSingleCustomer(int id)
        {
            return _customerTable.Where(j => j.Id == id).Single();
        }
    }
}