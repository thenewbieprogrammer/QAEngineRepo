using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace QAEngine.Application.Customers.Command
{
    public class DeleteCustomerCommand : IRequest
    {
        public string Id { get; set; }
    }
}
