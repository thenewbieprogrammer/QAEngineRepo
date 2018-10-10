using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using QAEngine.Application.Customers.Models;
using QAEngine.Domain.Entities;
using QAEngine.Persistence;

namespace QAEngine.Application.Customers.Command
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerModel>
    {
        private readonly QAEngineDbContext _context;

        public CreateCustomerCommandHandler(QAEngineDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                CustomerId = request.Id,
                Title = request.Title,
                FirstName = request.FirstName,
                LastName = request.Lastname,
                Address = request.Address,
                City = request.City,
                Region = request.Region,
                PostalCode = request.PostalCode,
                Country = request.Country,
                Phone = request.Phone,
                AccountCreated = request.AccountCreated,
                DateOfBirth = request.DateOfBirth
            };

            _context.Customers.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return CustomerModel.Create(entity);
        }
    }
}
