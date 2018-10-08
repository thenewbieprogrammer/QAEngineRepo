using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using QAEngine.Domain.Entities;
using QAEngine.Persistence;
using QAEngine.Application.Exceptions;

namespace QAEngine.Application.Customers.Command
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly QAEngineDbContext _context;

        public DeleteCustomerCommandHandler(QAEngineDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(request.Id);

            if(entity == null)
            {
                throw new DeleteFailureException(nameof(Customer), request.Id, "Sorry you cannot delete this customer!");
            }

            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
