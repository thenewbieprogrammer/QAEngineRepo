using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace QAEngine.Infrastructure.Interfaces
{
    public interface IRepository<TEntity>  where TEntity: class
    {
        // implemented generic repository contract methods

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
