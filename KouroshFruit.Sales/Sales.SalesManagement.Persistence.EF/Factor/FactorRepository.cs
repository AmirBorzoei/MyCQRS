using Framework.Core.Persistence;
using Framework.Persistence.EF;
using Sales.SalesManagement.Domain.Factor.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sales.SalesManagement.Persistence.EF.Factor
{
    public class FactorRepository : Repository<Domain.Factor.Factor>, IFactorRepository
    {
        public FactorRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        protected override IEnumerable<Expression<Func<Domain.Factor.Factor, object>>> GetIncludeExpressions()
        {
            return new List<Expression<Func<Domain.Factor.Factor, object>>>
                   {
                       f => f.FactorItems
                   };
        }
    }
}