//Author: Chase Steely
//Purpose: Orders Table Model
using System;


namespace BangazonCLI.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Closed { get; set; }

        //Foreign Key
        public int CustomerId { get; set; }

        //Foreign Key
        public int? PaymentId { get; set; }

        //This is the default constructor for the Orders Class used for testing, using the arguments listed above
        public Orders(int CustomerId)
        {
            this.CustomerId = CustomerId;
            this.PaymentId = null;
            this.Created = DateTime.Now;
            this.Closed = null;
        }

    }
}