﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using QAEngine.Application.Customers.Models;


namespace QAEngine.Application.Customers.Query
{
    public class GetCustomerListQuery : IRequest<List<CustomerListModel>>
    { 
       
    }
}
