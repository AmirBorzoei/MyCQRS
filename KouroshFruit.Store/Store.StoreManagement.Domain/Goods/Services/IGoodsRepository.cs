using System;
using System.Collections.Generic;

namespace Store.StoreManagement.Domain.Goods.Services
{
    public interface IGoodsRepository
    {
        Goods Get(Guid id);

        IList<Goods> GetAll();
        
        void Create(Goods goods);
    }
}