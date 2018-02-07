// Chris Miller
// Model of the OrderProduct join table

namespace BangazonCLI.Models
{
    public class OrderProduct
    {
        // PK - OrderProduct Id
        public int Id { get; }
        public int OrderId { get; }
        public int ProductId { get; }

        // Blank Constructor to create a dummy instance of the class
        public OrderProduct()
        {
            this.Id = 1;
            this.OrderId = 1;
            this.ProductId = 1;
        }
    }
}