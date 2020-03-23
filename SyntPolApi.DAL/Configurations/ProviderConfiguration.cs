using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.DAL.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(p => p.ProviderId);

            builder
                .Property(p => p.ProviderId)
                .UseIdentityColumn();

            builder
                .Property(p => p.FirstName)
                .IsRequired();

            builder
                .Property(p => p.LastName)
                .IsRequired();

            builder
                .Property(p => p.Street)
                .IsRequired();

            builder
                .Property(p => p.ZipCode)
                .IsRequired();


            builder
                .Property(p => p.City)
                .IsRequired();

            builder
                .Property(p => p.NIP)
                .IsRequired();

            builder
                .HasMany(pr => pr.Products)
                .WithOne(p => p.Provider);

            builder.ToTable("Providers");
        }
    }
}
