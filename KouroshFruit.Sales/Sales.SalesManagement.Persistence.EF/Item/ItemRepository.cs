using Framework.Core.Persistence;
using Framework.Persistence.EF;
using Sales.SalesManagement.Domain.Item.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sales.SalesManagement.Persistence.EF.Item
{
    public class ItemRepository : Repository<Domain.Item.Item>, IItemRepository
    {
        public ItemRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        protected override IEnumerable<Expression<Func<Domain.Item.Item, object>>> GetIncludeExpressions()
        {
            yield break;
        }
    }
}