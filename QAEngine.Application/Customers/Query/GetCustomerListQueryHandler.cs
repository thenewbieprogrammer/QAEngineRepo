using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QAEngine.Application.Customers.Models;
using QAEngine.Persistence;

namespace QAEngine.Application.Customers.Query
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerListModel>>
    {
        private readonly QAEngineDbContext _context;

        public GetCustomerListQueryHandler(QAEngineDbContext context)
        {
            _context = context;
        }

        public Task<List<CustomerListModel>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            return _context.Customers.Select(c =>
                new CustomerListModel
                {
                    Id = c.CustomerId,
                    Name = c.FirstName + " " + c.Lastname
                }).ToListAsync(cancellationToken);
        }

    }
}
