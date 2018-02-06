namespace BangazonCLI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long Phone { get; set; }

        public Customer()
        {
            this.Id = 1;
            this.Name = "Bob";
            this.Street = "123 derp";
            this.City = "Derpville";
            this.State = "TN";
            this.Zip = 37029;
            this.Phone = 6155555555;
        }

        public Customer(int id, string name, string street, string city, string state, int zip, int phone)
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