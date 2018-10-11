using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using QAEngine.Application.Customers.Models;

namespace QAEngine.Web.ViewModels
{
    public class NewCustomerFormViewModel : CustomerModel
    {
        public string _Title;
        public string _FirstName;
        public string _LastName;
        public string _Address;
        public string _City;
        public string _Region;
        public string _PostalCode;
        public string _Country;
        public string _Phone;
        public DateTime _AccountCreated;
        [DataType(DataType.Date)]
        public DateTime _DateOfBirth;
        public NewCustomerFormViewModel(CustomerModel customerModel)
        {
            _Title = customerModel.Title;
            _FirstName = customerModel.FirstName;
            _LastName = customerModel.LastName;
            _Address = customerModel.Address;
            _City = customerModel.City;
            _Region = customerModel.Region;
            _PostalCode = customerModel.Region;
            _Country = customerModel.Country;
            _Phone = customerModel.Phone;
            _AccountCreated = customerModel.AccountCreated;
            _DateOfBirth = customerModel.DateOfBirth.Date;

        }
    }
}
