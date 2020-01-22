using Framework.Core.Domain;
using System;

namespace Sales.SalesManagement.Domain.Item
{
    public class Item : AggregateRoot
    {
        public Item(string title, string description, Guid goodsId)
        {
            SetTitle(title);
            SetDescription(description);
            SetGoodsId(goodsId);
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public Guid GoodsId { get; private set; }

        private void SetTitle(string title)
        {
            Title = title;
        }

        private void SetDescription(string description)
        {
            Description = description;
        }

        private void SetGoodsId(Guid goodsId)
        {
            GoodsId = goodsId;
        }

        public static Item CreateItem(string title, string description, Guid goodsId)
        {
            var item = new Item(title, description, goodsId);
            return item;
        }
    }
}