using System;
using System.Collections.Generic;
using System.Text;

namespace QAEngine.Infrastructure.Interfaces.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        public void Dispose()
        {
            // Dispose of unmanaged resources
            Dispose(true);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
