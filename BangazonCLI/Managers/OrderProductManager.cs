using System.Collections.Generic;
using BangazonCLI.Models;

namespace BangazonCLI.Managers
{
    public class OrderProductManager
    {
        private List<OrderProduct> _orderProductList = new List<OrderProduct>();

        public void Add(OrderProduct orderProduct)
        {
            _orderProductList.Add(orderProduct);
        }

        public List<OrderProduct> GetAllOrderProduct => _orderProductList;
    }
}