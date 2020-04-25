using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.DAL.Configurations
{
    public class InvoiceEdiConfiguration : IEntityTypeConfiguration<InvoiceEdi>
    {
        public void Configure(EntityTypeBuilder<InvoiceEdi> builder)
        {
            builder.HasKey(ie => ie.InvoiceEdiId);

            builder
                .Property(ie => ie.InvoiceEdiId)
                .UseIdentityColumn();

            builder
                .Property(ie => ie.Username)
                .IsRequired();

            builder
                .Property(ie => ie.EdiString)
                .IsRequired();

            builder
                .HasOne(ie => ie.Invoice)
                .WithOne(i => i.InvoiceEdi)
                .HasForeignKey<Invoice>(i => i.InvoiceEdiId);
        }
    }
}
