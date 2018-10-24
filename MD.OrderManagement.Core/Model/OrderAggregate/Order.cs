using MD.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Core.Model.OrderAggregate
{
    public class Order : Entity<int>
    {
        public int CustomerId { get; set; }
        public OrderStatusCode OrderStatusCode { get; set; }
        public DateTime DateOrderPlaced { get; set; }
        public string OrderDetails { get; set; }
        private List<OrderItem> orderItems;

        public IEnumerable<OrderItem> OrderItems
        {
            get { return orderItems.AsEnumerable(); }
            set { orderItems = value.ToList();  }
        }

        public Order()
        {

        }

        public Order(int customerId, DateTime datePlaced, string details)
        {
            if (datePlaced == null)
            {
                datePlaced = DateTime.Now;
            }

            this.DateOrderPlaced = datePlaced;
            this.CustomerId = customerId;
            this.OrderDetails = details;

            orderItems = new List<OrderItem>();
        }

        public void AddItem(OrderItem item)
        {
            var existedItem = orderItems.FirstOrDefault(t => t.Id == item.Id);
            if (existedItem != null)
            {
                existedItem.Quantity++;
            }
            else
            {
                item.OrderId = this.Id;
                orderItems.Add(item);
            }
        }

        public void RemoveItem(OrderItem item)
        {
            var existedItem = orderItems.FirstOrDefault(t => t.Id == item.Id);
            if (existedItem != null)
            {
                orderItems.Remove(item);
            }
        }
    }
}