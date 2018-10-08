using System;
using System.Collections.Generic;
using System.Text;
using QAEngine.Application.Customers.Models;
using MediatR;

namespace QAEngine.Application.Customers.Command
{
    public class UpdateCustomerCommand : IRequest<CustomerModel>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public DateTime? AccountCreated { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
