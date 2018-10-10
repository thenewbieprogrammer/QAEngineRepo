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
            builder.ToTable("Customers");

            builder.HasKey(e => e.CustomerId);

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasMaxLength(8)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Title).HasColumnName("Title").HasMaxLength(5);
            builder.Property(e => e.FirstName).HasColumnName("FirstName").HasMaxLength(10);
            builder.Property(e => e.LastName).HasColumnName("LastName").HasMaxLength(10);
            builder.Property(e => e.Address).HasColumnName("Address").HasMaxLength(45);
            builder.Property(e => e.City).HasColumnName("City").HasMaxLength(15);
            builder.Property(e => e.Region).HasColumnName("Region").HasMaxLength(20);
            builder.Property(e => e.Country).HasColumnName("Country").HasMaxLength(15);
            builder.Property(e => e.PostalCode).HasColumnName("PostalCode").HasMaxLength(6);
            builder.Property(e => e.Phone).HasColumnName("Phone").HasMaxLength(15);
            builder.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth").IsRequired(true);
            
            // develop note configuration
        }
    }
}
