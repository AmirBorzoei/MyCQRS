using Framework.Core.Event;
using System;

namespace Store.StoreManagement.Domain.Contract.Goods
{
    [Serializable]
    public class GoodsCreatedEvent : Event
    {
        public GoodsCreatedEvent(Guid createdGoodsId, string title)
        {
            CreatedGoodsId = createdGoodsId;
            Title = title;
        }

        public Guid CreatedGoodsId { get; private set; }

        public string Title { get; private set; }
    }
}