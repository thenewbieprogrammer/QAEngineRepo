using System;
using System.Collections.Generic;
using System.Text;

namespace QAEngine.Application.Customers.Models
{
    public class CustomerListModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        
    }
}