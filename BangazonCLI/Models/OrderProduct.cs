namespace BangazonCLI.Models
{
    public class OrderProduct
    {
        private int _id { get; }
        private int _customerId { get; }
        private int _productId { get; }

        public OrderProduct()
        {
            this._id = 1;
            this._customerId = 1;
            this._productId = 1;
        }
    }
}