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
            modelBuilder.Entity<Order>().HasKey(c => c.Id);
            modelBuilder.Entity<Order>().HasMany<OrderItem>(c => c.OrderItems).WithOne(t => t.Order).HasForeignKey(t => t.OrderId);
            modelBuilder.Entity<OrderItem>().HasKey(c => c.Id);
            modelBuilder.Entity<OrderItem>().Ignore(a => a.State);
            modelBuilder.Entity<OrderItem>().Ignore(t => t.Price);

            //modelBuilder.Entity<OrderItem>().Property(t => t.Price.Currency).HasColumnName("PriceUnit");
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
