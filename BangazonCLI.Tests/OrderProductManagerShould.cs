//Chris Miller
//Integration tests for OrderProdcut / OrderProduct Manager

using System;
using BangazonCLI.Managers;
using BangazonCLI.Models;
using Xunit;

namespace BangazonCLI.Tests
{
    public class OrderProductManagerShould
    {
        //Create global variables for tests
        private OrderProduct op {get; set;}
        private OrderProductManager opm {get; set;}

        //Constructor to instatiate OrderProductManager / OrderProduct
        public OrderProductManagerShould()
        {
            this.opm = new OrderProductManager();
            this.op = new OrderProduct();
        }


        //Test that the add function adds the object to the _orderProductList and the GetAllOrderProduct method returns it 
        [Fact]
        public void GetAllOrderProduct()
        {
            opm.Add(op);

            Assert.Contains(op, opm.GetAllOrderProduct());
        }

        //Test that the add function adds the object to the _orderProductList and the GetOrderProductByOrderId method returns it
        //when the correct order id is passed in 
        [Fact]
        public void GetOrderProductById()
        {
            opm.Add(op);

            Assert.Contains(op, opm.GetOrderProductByOrderId(1));
        }
    }
}
