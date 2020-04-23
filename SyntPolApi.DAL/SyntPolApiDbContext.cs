using Microsoft.EntityFrameworkCore;
using SyntPolApi.Core.Models;
using SyntPolApi.DAL.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.DAL
{
    public class SyntPolApiDbContext : DbContext
    {
        public SyntPolApiDbContext(DbContextOptions<SyntPolApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProviderConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new InvoiceConfiguration());
        }
    }
}
