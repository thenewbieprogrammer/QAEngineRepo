using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace QAEngine.Persistence
{
    public class ContextFactory : IDesignTimeDbContextFactory<QAEngineDbContext>
    {
        public ContextFactory()
        { }

        //public QAEngineDbContext Create(DbContextFactoryOptions options)
        //{
        //    var builder = new DbContextOptionsBuilder<QAEngineDbContext>();
        //    builder.UseSqlServer("Server=(localdb)\\localdb;Database=QAEngine;Trusted_Connection=True;MultipleActiveResultSets=true",
        //        optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(QAEngineDbContext).GetTypeInfo().Assembly.GetName().Name));

        //    return new QAEngineDbContext(builder.Options);
        //}

        public QAEngineDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<QAEngineDbContext>();
            builder.UseSqlServer("Server=(localdb)\\localdb;Database=QAEngine;Trusted_Connection=True;MultipleActiveResultSets=true",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(QAEngineDbContext).GetTypeInfo().Assembly.GetName().Name));

            return new QAEngineDbContext(builder.Options);
        }

        //public QAEngineDbContext CreateDbContext(string[] args)
        //{
        //    var builder = new DbContextOptionsBuilder<QAEngineDbContext>();
        //    builder.UseSqlServer(
        //        "Server=(localdb)\\localdb;Database=QAEngine;Trusted_Connection=True;MultipleActiveResultSets=true");

        //    return new QAEngineDbContext(builder.Options);
        //}
    }
}
