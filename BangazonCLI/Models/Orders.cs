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

        //Defining these foreign key explicitly allows the one-to-many relationship in the customer and Payment models.

        //Foreign Key
        public int CustomerId { get; set; }

        //Foreign Key
        public int? PaymentId { get; set; }

          //This is the default constructor for the Orders Class used for testing, using the arguments listed above
        public Orders()
        {
            this.Id = 1;
            this.CustomerId = 1;
            this.PaymentId = null;
            this.Created = DateTime.Now;
            this.Closed = null;
        }

    }
}