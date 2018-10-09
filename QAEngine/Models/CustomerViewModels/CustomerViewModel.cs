using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QAEngine.Application.Customers.Models;

namespace QAEngine.Web.Models.CustomerViewModels
{
    public class CustomerViewModel
    {
        public string _Id;
        public string _FirstName;
        public string _LastName;
        public string _Address;
        public string _City;
        public string _Region;
        public string _Country;
        public string _PostalCode;
        public string _Phone;
        public DateTime _DateOfBirth;
        public DateTime _AccountCreated;

        public CustomerViewModel(CustomerModel customer)
        {
            _Id = customer.Id;
            _FirstName = customer.FirstName;
            _LastName = customer.Lastname;
            _Address = customer.Address;
            _City = customer.City;
            _Region = customer.Region;
            _Country = customer.Country;
            _PostalCode = customer.PostalCode;
            _Phone = customer.Phone;
            _DateOfBirth = customer.DateOfBirth;
            _AccountCreated = customer.AccountCreated;
        }
    }
}
