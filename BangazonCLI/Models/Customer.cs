//Author: Max Wolf
//Purpose: Creates a model of what should be contained in the customer table

namespace BangazonCLI.Models
{
    //model of Customer class
    public class Customer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Phone { get; set; }

        //method that specifies what can be passed into the Customer class for a customer that will be stored in the customer table
        public Customer(int id, string name, string street, string city, string state, int zip, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Street = street;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Phone = phone;
        }

    }
}