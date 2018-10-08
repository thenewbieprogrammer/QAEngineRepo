using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAEngine.Domain.Entities;


namespace QAEngine.Persistence.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.CustomerId);

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasMaxLength(8)
                .ValueGeneratedNever();

            builder.Property(e => e.Title).HasMaxLength(5);
            builder.Property(e => e.FirstName).HasMaxLength(10);
            builder.Property(e => e.Lastname).HasMaxLength(10);
            builder.Property(e => e.Address).HasMaxLength(45);
            builder.Property(e => e.City).HasMaxLength(15);
            builder.Property(e => e.Region).HasMaxLength(20);
            builder.Property(e => e.Country).HasMaxLength(15);
            builder.Property(e => e.PostalCode).HasMaxLength(6);
            builder.Property(e => e.Phone).HasMaxLength(15);
            builder.Property(e => e.DateOfBirth).IsRequired(true);
        }
    }
}
