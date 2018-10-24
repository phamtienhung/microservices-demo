using System;
using System.Linq;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Model.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Data.Repositories
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            this._context = context;
        }

        public Order GetOrder(int orderId)
        {
            var order = _context.Orders.Include(t => t.OrderItems).FirstOrDefault(t => t.Id == orderId);
            return order;
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
