using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QAEngine.Application.Customers.Models;
using QAEngine.Application.Exceptions;
using QAEngine.Domain.Entities;
using QAEngine.Persistence;


namespace QAEngine.Application.Customers.Query
{
    public class GetCustomerModelQueryHandler : IRequestHandler<GetCustomerModelQuery, CustomerModel>
    {
        private readonly QAEngineDbContext _context;

        public GetCustomerModelQueryHandler(QAEngineDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerModel> Handle(GetCustomerModelQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(request.Id);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            return new CustomerModel
            {
                Id = entity.CustomerId,
                Title = entity.Title,
                FirstName = entity.FirstName,
                Lastname = entity.Lastname,
                Address = entity.Address,
                City = entity.City,
                Region = entity.Region,
                PostalCode = entity.PostalCode,
                Country = entity.Country,
                Phone = entity.Phone,
                DateOfBirth = entity.DateOfBirth
            };
        }
    }
}
