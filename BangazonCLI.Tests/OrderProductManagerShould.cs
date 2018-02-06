using System;
using BangazonCLI.Managers;
using BangazonCLI.Models;
using Xunit;

namespace BangazonCLI.Tests
{
    public class OrderProductManagerShould
    {
        [Fact]
        public void AddProductToUsersOrder()
        {
            OrderProductManager opm = new OrderProductManager();
            OrderProduct op = new OrderProduct();

            opm.Add(op);

            Assert.Contains(op, opm.GetAllOrderProduct);
        }
    }
}
