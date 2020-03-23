using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder
                .Property(o => o.OrderId)
                .UseIdentityColumn();

            builder
                .Property(o => o.OrderValue)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .HasMany(o => o.OrderItems)
                .WithOne(or => or.Order)
                .HasForeignKey(o => o.OrderId);

            builder.ToTable("Orders");
        }
    }
}
