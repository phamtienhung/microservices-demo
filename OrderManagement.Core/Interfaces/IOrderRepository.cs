using OrderManagement.Core.Model.OrderAggregate;

namespace OrderManagement.Core.Interfaces
{
    public interface IOrderRepository
    {
        void Update(Order order);

        Order GetOrder(int orderId);
    }
}