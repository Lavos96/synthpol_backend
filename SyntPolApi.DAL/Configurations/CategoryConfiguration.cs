using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.CategoryId);

            builder
                .Property(p => p.CategoryId)
                .UseIdentityColumn();

            builder
                .Property(p => p.CategoryName)
                .IsRequired();

            builder
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            builder.ToTable("Categories");
        }
    }
}
