using Framework.Core.Persistence;
using Framework.Persistence.EF;
using Store.StoreManagement.Domain.Goods.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Store.StoreManagement.Persistence.EF.Goods
{
    public class GoodsRepository : Repository<Domain.Goods.Goods>, IGoodsRepository
    {
        public GoodsRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        protected override IEnumerable<Expression<Func<Domain.Goods.Goods, object>>> GetIncludeExpressions()
        {
            yield break;
        }
    }
}