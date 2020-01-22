using Framework.Core.CommandHandling;
using System;

namespace Sales.SalesManagement.ApplicationService.Contract.Item
{
    public class CreateItemCommand : Command
    {
        public CreateItemCommand(string title, string description, Guid goodsId)
        {
            Title = title;
            Description = description;
            GoodsId = goodsId;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public Guid GoodsId { get; private set; }
    }
}