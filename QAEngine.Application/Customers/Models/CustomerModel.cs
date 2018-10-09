using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using QAEngine.Domain.Entities;

namespace QAEngine.Application.Customers.Models
{
    public class CustomerModel
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
        public DateTime AccountCreated { get; set; }
        public DateTime DateOfBirth { get; set; }


        public static Expression<Func<Customer, CustomerModel>> Projection
        {
            get
            {
                return customer => new CustomerModel
                {
                    Id = customer.CustomerId,
                    Title = customer.Title,
                    FirstName = customer.FirstName,
                    Lastname = customer.Lastname,
                    Address = customer.Address,
                    City = customer.City,
                    Region = customer.Region,
                    PostalCode = customer.PostalCode,
                    Country = customer.Country,
                    Phone = customer.Phone,
                    AccountCreated = customer.AccountCreated,
                    DateOfBirth = customer.DateOfBirth

                };
            }
        }

        public static CustomerModel Create(Customer customer)
        {
            return Projection.Compile().Invoke(customer);
        }

    }
}
