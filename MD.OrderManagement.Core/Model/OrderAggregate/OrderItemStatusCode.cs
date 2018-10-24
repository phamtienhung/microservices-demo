namespace OrderManagement.Core.Model.OrderAggregate
{
    public enum OrderItemStatusCode
    {
        PLACED,
        PROCESSING,
        COMPLETED,
        CANCELLED,
        REJECTED,
        ERROR,
    }
}