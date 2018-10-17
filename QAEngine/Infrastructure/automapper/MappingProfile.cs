using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QAEngine.Application.Customers.Models;
using QAEngine.Web.ViewModels;
using AutoMapper;

namespace QAEngine.Web.Infrastructure.automapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerModel, FindCustomer>()
                 .ReverseMap();
        }
    }
}
