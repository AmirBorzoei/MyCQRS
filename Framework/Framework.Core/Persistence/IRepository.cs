using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Core.Persistence
{
    public interface IRepository<T> where T : AggregateRoot
    {
        long Count(Expression<Func<T, bool>> predicate);

        bool IsExist(Guid id);

        bool IsExist(Expression<Func<T, bool>> predicate);

        T Get(Guid id);

        T Get(Expression<Func<T, bool>> predicate);

        IList<T> GetList(Expression<Func<T, bool>> predicate);

        IList<T> GetAll();

        void Create(T aggregate);

        void Update(T aggregate);

        void Delete(T aggregate);
    }
}
