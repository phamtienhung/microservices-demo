using MD.SharedKernel;
using MD.SharedKernel.ValueObjects;

namespace OrderManagement.Core.Model.OrderAggregate
{
    public class OrderItem : Entity<int>
    {
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public OrderItemStatusCode StatusCode { get; set; }
        public string OrderItemDetails { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public Money Price { get; set; }
    }
}