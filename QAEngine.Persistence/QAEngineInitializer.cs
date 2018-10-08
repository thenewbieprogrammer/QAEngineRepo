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
            throw new NotImplementedException();
        }
    }
}
