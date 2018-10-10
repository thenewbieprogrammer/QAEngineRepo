using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QAEngine.Domain.Entities;

namespace QAEngine.Persistence
{
    public class QAEngineInitializer
    {
        private readonly Dictionary<int, Customer> Customers = new Dictionary<int, Customer>();

        public static void Initialize(QAEngineDbContext context)
        {
            var initializer = new QAEngineInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(QAEngineDbContext context)
        {
            context.Database.EnsureCreated();

            if(context.Customers.Any())
            {
                return; // DB has been seeded
            }

            SeedCustomers(context);
        }

        private void SeedCustomers(QAEngineDbContext context)
        {
            var customer = new[]
            {
               new Customer { CustomerId = "993HAGH", Title = "Mr", FirstName = "Bilaal", LastName = "Nadeem", Address="88 Meir Road", City = "Stoke-On-Trent", Region = "Staffordshire", PostalCode = "ST3 7JB", Country = "United Kingdom", Phone = "07702 575 157", AccountCreated = DateTime.Parse("October 10 2018") , DateOfBirth = DateTime.Parse("September 18 1995")}
            };

            context.Customers.AddRange(customer);
            context.SaveChanges();
        }
    }
}
