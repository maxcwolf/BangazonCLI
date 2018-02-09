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
            //Return the ID of the entry to the database
            int _id = opm.Add(5,6);

            //Create the objec that should be returned from the database
            OrderProduct op = new OrderProduct(_id, 5, 6);

            //Get all of the order products from the database
            List<OrderProduct> AllOrderedProducts = opm.GetAllOrderProduct();

            //Check to make sure that the properties on my constructed object are equal to the properties of the last item
            //returned from the database
            Assert.Equal(op.Id, AllOrderedProducts[AllOrderedProducts.Count-1].Id);
            Assert.Equal(op.OrderId, AllOrderedProducts[AllOrderedProducts.Count-1].OrderId);
            Assert.Equal(op.ProductId, AllOrderedProducts[AllOrderedProducts.Count-1].ProductId);

            //Delete the entry that was just added to the database
            opm.DeleteOrderProduct(_id);

            //Requery the database and return a new list
            AllOrderedProducts = opm.GetAllOrderProduct();

            //Check to make sure that the item was deleted
            Assert.NotEqual(op.Id, AllOrderedProducts[AllOrderedProducts.Count-1].Id);
        }

        //Test that the add function adds the object to the _orderProductList and the GetOrderProductByOrderId method returns it
        //when the correct order id is passed in 
        [Fact]
        public void GetOrderProductById()
        {
            //Return the ID of the entry to the database
            int _id = opm.Add(9,6);
            //Create the objec that should be returned from the database
            OrderProduct op = new OrderProduct(_id, 9, 6);

            //Get all of the order products from the database
            List<OrderProduct> ProductsByOrder = opm.GetOrderProductByOrderId(9);

            //Check to make sure that the properties on my constructed object are equal to the properties of the last item
            //returned from the database
            Assert.Equal(op.Id, ProductsByOrder[ProductsByOrder.Count-1].Id);
            Assert.Equal(op.OrderId, ProductsByOrder[ProductsByOrder.Count-1].OrderId);
            Assert.Equal(op.ProductId, ProductsByOrder[ProductsByOrder.Count-1].ProductId);

            //Delete the entry that was just added to the database
            opm.DeleteOrderProduct(_id);

            //Requery the database and return a new list
            ProductsByOrder = opm.GetOrderProductByOrderId(9);

            //Check to make sure that the item was deleted
            Assert.NotEqual(op.Id, ProductsByOrder[ProductsByOrder.Count-1].Id);
        }
    }
}
