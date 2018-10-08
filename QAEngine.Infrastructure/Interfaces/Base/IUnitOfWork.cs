using System;
using System.Collections.Generic;
using System.Text;

namespace QAEngine.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
        
    {
        //implement unit of work to share a single database context.
        //IDisposable; handles releasing of unmanaged resources.

            
        bool SaveChanges();
    }
}
