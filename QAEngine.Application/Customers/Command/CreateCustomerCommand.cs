using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;
using QAEngine.Application.Customers.Models;

namespace QAEngine.Application.Customers.Command
{
    public class CreateCustomerCommand : IRequest<CustomerModel>
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public DateTime AccountCreated { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
