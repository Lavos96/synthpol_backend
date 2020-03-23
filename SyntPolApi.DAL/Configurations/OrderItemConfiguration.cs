using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.DAL.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.OrderItemId);

            builder
                .Property(oi => oi.OrderItemId)
                .UseIdentityColumn();

            builder
                .Property(oi => oi.BruttoPrice)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .Property(oi => oi.Discount)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .HasOne(oi => oi.Product)
                .WithMany(pr => pr.OrderItems)
                .HasForeignKey(pr => pr.ProductId);

            builder
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(pr => pr.OrderId); ;

            builder.ToTable("OrderItems");
        }
    }
}
