//Chris Miller
//Integration tests for OrderProdcut / OrderProduct Manager

using System;
using System.Collections.Generic;
using BangazonCLI.Managers;
using BangazonCLI.Models;
using Xunit;

namespace BangazonCLI.Tests
{
    public class OrderProductManagerShould
    {
        //Create global variables for tests
        private OrderProductManager opm {get; set;}

        //Constructor to instatiate OrderProductManager / OrderProduct
        public OrderProductManagerShould()
        {
            this.opm = new OrderProductManager("BANGAZON_CLI_TEST");
        }

        //Test that the add function adds the object to the _orderProductList and the GetAllOrderProduct method returns it 
        [Fact]
        public void GetAllOrderProduct()
        {
            int _id = opm.Add(5,6);
            OrderProduct op = new OrderProduct(_id, 5, 6);

            List<OrderProduct> AllOrderedProducts = opm.GetAllOrderProduct();

            Assert.Equal(op.Id, AllOrderedProducts[AllOrderedProducts.Count-1].Id);
            Assert.Equal(op.OrderId, AllOrderedProducts[AllOrderedProducts.Count-1].OrderId);
            Assert.Equal(op.ProductId, AllOrderedProducts[AllOrderedProducts.Count-1].ProductId);

            opm.DeleteOrderProduct(_id);

            AllOrderedProducts = opm.GetAllOrderProduct();

            Assert.NotEqual(op.Id, AllOrderedProducts[AllOrderedProducts.Count-1].Id);
        }

        //Test that the add function adds the object to the _orderProductList and the GetOrderProductByOrderId method returns it
        //when the correct order id is passed in 
        [Fact]
        public void GetOrderProductById()
        {
            int _id = opm.Add(9,6);
            OrderProduct op = new OrderProduct(_id, 9, 6);

            List<OrderProduct> ProductsByOrder = opm.GetOrderProductByOrderId(9);

            Assert.Equal(op.Id, ProductsByOrder[ProductsByOrder.Count-1].Id);
            Assert.Equal(op.OrderId, ProductsByOrder[ProductsByOrder.Count-1].OrderId);
            Assert.Equal(op.ProductId, ProductsByOrder[ProductsByOrder.Count-1].ProductId);

            opm.DeleteOrderProduct(_id);

            ProductsByOrder = opm.GetOrderProductByOrderId(9);

            Assert.NotEqual(op.Id, ProductsByOrder[ProductsByOrder.Count-1].Id);
        }
    }
}
