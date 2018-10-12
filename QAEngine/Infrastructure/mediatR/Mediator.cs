using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace QAEngine.Web.Infrastructure
{
    public class Mediator 
    {
        public Mediator(ServiceFactory serviceFactory)
        {

        }

        public delegate object ServiceFactory(Type serviceType);

        
    }
}
