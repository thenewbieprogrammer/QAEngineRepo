using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QAEngine.Application.Customers.Models;
namespace QAEngine.Web.ViewModels
{
    public class FindCustomer : CustomerModel
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
        // recieve data from here to pass from controller. If yes then the required view will change dynamically.

        public bool isEdit { get; set; }
        public bool isUpdate { get; set; }
        public bool isDelete { get; set; }

    }
}
