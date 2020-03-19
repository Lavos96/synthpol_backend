using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder
                .Property(p => p.ProductId)
                .UseIdentityColumn();

            builder
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Property(p => p.PhotoString)
                .IsRequired();

            builder
                .Property(p => p.NettoPrice)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(m => m.CategoryId);

            builder
                .HasOne(p => p.Provider)
                .WithMany(pr => pr.Products)
                .HasForeignKey(p => p.ProviderId);

            builder.ToTable("Products");
        }
    }
}
