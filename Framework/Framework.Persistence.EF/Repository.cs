using Framework.Core.Domain;
using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Persistence.EF
{
    public abstract class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        protected readonly DbContextBase dbContext;

        protected Repository(IDbContext dbContext)
        {
            this.dbContext = dbContext as DbContextBase;
        }

        public long Count(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Count(predicate);
        }

        public bool IsExist(Guid id)
        {
            return dbContext.Set<T>().Any(e => e.Id == id);
        }

        public bool IsExist(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Any(predicate);
        }

        public T Get(Guid id)
        {
            var aggregate = ConvertToAggregate(dbContext.Set<T>());
            return aggregate.FirstOrDefault(e => e.Id == id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            var aggregate = ConvertToAggregate(dbContext.Set<T>());
            return aggregate.FirstOrDefault(predicate);
        }

        public IList<T> GetList(Expression<Func<T, bool>> predicate)
        {
            var aggregate = ConvertToAggregate(dbContext.Set<T>());
            return aggregate.Where(predicate).ToList();
        }

        public IList<T> GetAll()
        {
            var aggregate = ConvertToAggregate(dbContext.Set<T>());
            return aggregate.ToList();
        }

        public void Create(T aggregate)
        {
            SetPersistableObjectForCreate(aggregate);
            aggregate.RowVersion = new byte[8];
            dbContext.Set<T>().Add(aggregate);
        }

        public void Update(T aggregate)
        {
            SetPersistableObjectForUpdate(aggregate);
        }

        public void Delete(T aggregate)
        {
            dbContext.Set<T>().Remove(aggregate);
        }

        protected abstract IEnumerable<Expression<Func<T, object>>> GetIncludeExpressions();

        private IQueryable<T> ConvertToAggregate(IQueryable<T> set)
        {
            var result = set;
            var includeExpressions = GetIncludeExpressions();

            if (includeExpressions != null)
            {
                foreach (var expression in includeExpressions)
                {
                    result = result.Include(expression);
                }
            }

            return result;
        }

        private static void SetPersistableObjectForCreate(T aggregate)
        {
            var persistableObject = aggregate as IPersistableObject;
            if (persistableObject != null)
            {
                persistableObject.CreatedDate = DateTime.Now;
                persistableObject.CreatedBy = "";
                persistableObject.LastChangedBy = "";
            }
        }

        private static void SetPersistableObjectForUpdate(T aggregate)
        {
            var persistableObject = aggregate as IPersistableObject;
            if (persistableObject != null)
            {
                persistableObject.LastChangedDate = DateTime.Now;
                persistableObject.LastChangedBy = "";
            }
        }
    }
}