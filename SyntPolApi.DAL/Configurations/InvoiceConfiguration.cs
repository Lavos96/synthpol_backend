using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.DAL.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.InvoiceId);
            
            builder
                .Property(i => i.InvoiceId)
                .UseIdentityColumn();

            builder
                .Property(i => i.Name)
                .IsRequired();

            builder
                .Property(i => i.Street)
                .IsRequired();

            builder
                .Property(i => i.ZipCode)
                .IsRequired();

            builder
                .Property(i => i.City)
                .IsRequired();

            builder
                .Property(i => i.NIP)
                .IsRequired();

            builder
                .Property(i => i.Username)
                .IsRequired();

            builder
                .HasOne(i => i.Order)
                .WithOne(o => o.Invoice)
                .HasForeignKey<Order>(o => o.InvoiceId);

            builder
                .HasOne(i => i.InvoiceEdi)
                .WithOne(ie => ie.Invoice)
                .HasForeignKey<InvoiceEdi>(ie => ie.InvoiceId);

            builder.ToTable("Invoices");
        }
    }
}
