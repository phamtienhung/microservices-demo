using System;
using NUnit.Framework;
using OrderManagement.Data;
using OrderManagement.Data.Repositories;

namespace MD.OrderManagement.Data.Test
{
    [TestFixture]
    public class OrderRepositoryTest
    {       
        [Test]
        public void GetOrder()
        {
            // Arrange
            var repo = new OrderRepository(new OrderDbContext());

            // Act
            var order = repo.GetOrder(1);

            // Assert
            Assert.IsNotNull(order);

        }
    }
}
