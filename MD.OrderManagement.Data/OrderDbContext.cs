using MD.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Model.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Data
{
    public class OrderDbContext : DbContext
    {
        private static bool _created = false;
        public OrderDbContext()
        {
            if (!_created)
            {
                _created = true;
                //Database.EnsureDeleted();
                //Database.EnsureCreated();
            }            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=H:\DatabaseSQLite\VOrder.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(t => t.Id);
                o.HasMany<OrderItem>(c => c.OrderItems).WithOne(t => t.Order).HasForeignKey(t => t.OrderId);
            });

            modelBuilder.Entity<OrderItem>(o =>
            {
                o.Ignore(t => t.State);
                o.HasKey(t => t.Id);
                o.OwnsOne<Money>(t => t.Price, price =>
                {
                    price.Property(x => x.Amount).HasColumnName("PriceValue");
                    price.Property(x => x.Currency).HasColumnName("PriceUnit");
                });
            });
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
