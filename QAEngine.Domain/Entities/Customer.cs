using System;
using System.Collections.Generic;
using System.Text;

namespace QAEngine.Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
            Notes = new HashSet<Note>();
        }

        public string CustomerId { get; set; }
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


        public ICollection<Note> Notes { get; private set; }
    }
}
