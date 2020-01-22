using System;
using System.Collections.Generic;

namespace Sales.SalesManagement.Domain.Item.Services
{
    public interface IItemRepository
    {
        Item Get(Guid id);

        IList<Item> GetAll();

        void Create(Item item);
    }
}