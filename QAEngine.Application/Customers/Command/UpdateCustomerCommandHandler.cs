using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using QAEngine.Application.Customers.Models;
using QAEngine.Application.Exceptions;
using QAEngine.Domain.Entities;
using QAEngine.Persistence;



namespace QAEngine.Application.Customers.Command
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerModel>
    {
        private readonly QAEngineDbContext _context;



        public UpdateCustomerCommandHandler(QAEngineDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .SingleAsync(c => c.CustomerId == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            entity.Title = request.Title;
            entity.FirstName = request.FirstName;
            entity.Lastname = request.Lastname;
            entity.Address = request.Address;
            entity.City = request.City;
            entity.Region = request.Region;
            entity.PostalCode = request.PostalCode;
            entity.Country = request.Country;
            entity.Phone = request.Phone;
            entity.AccountCreated = request.AccountCreated;
            entity.DateOfBirth = request.DateOfBirth;

            await _context.SaveChangesAsync(cancellationToken);

            return CustomerModel.Create(entity);
        }


    }
}
