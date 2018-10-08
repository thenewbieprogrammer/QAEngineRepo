using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QAEngine.Domain.Entities;
using QAEngine.Persistence.Extensions;
namespace QAEngine.Persistence
{
    public class QAEngineDbContext : DbContext
    {

        public QAEngineDbContext(DbContextOptions<QAEngineDbContext> options)
            : base(options)
        { }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteDescription> NoteDescriptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }

    }
}
