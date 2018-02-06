//Chris Miller
//OrderProduct Manager

using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Models;

namespace BangazonCLI.Managers
{
    public class OrderProductManager
    {
        //List to hold all of the OrderProduct
        private List<OrderProduct> _orderProductList = new List<OrderProduct>();

        //Adds an OrderProduct to the list
        public void Add(OrderProduct orderProduct)
        {
            _orderProductList.Add(orderProduct);
        }

        // return all of the OrderProducts
        public List<OrderProduct> GetAllOrderProduct()
        {
            return _orderProductList;
        }

        // return all of the OrderProducts associated with the OrderId passed into the function
        public List<OrderProduct> GetOrderProductByOrderId(int OrderId)
        {
            return _orderProductList.Where(x => x.OrderId == OrderId).ToList();
        }
    }
}