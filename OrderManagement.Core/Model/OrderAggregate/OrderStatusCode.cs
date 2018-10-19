namespace OrderManagement.Core.Model.OrderAggregate
{
    public enum OrderStatusCode
    {
        PLACED,
        PROCESSING,
        COMPLETED,
        CANCELLED,
        REJECTED,
        ERROR,
    }
}