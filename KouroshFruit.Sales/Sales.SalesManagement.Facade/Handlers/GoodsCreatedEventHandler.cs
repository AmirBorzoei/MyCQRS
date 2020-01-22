using Framework.Core.Event;
using Sales.SalesManagement.ApplicationService.Contract.Item;
using Sales.SalesManagement.Facade.Contract;
using Store.StoreManagement.Domain.Contract.Goods;

namespace Sales.SalesManagement.Facade.Handlers
{
    public class GoodsCreatedEventHandler : IEventHandler<GoodsCreatedEvent>
    {
        private readonly IItemFacade itemFacade;

        public GoodsCreatedEventHandler(IItemFacade itemFacade)
        {
            this.itemFacade = itemFacade;
        }

        public void Handle(GoodsCreatedEvent eventToHandle)
        {
            var command = new CreateItemCommand(eventToHandle.Title, "Create From Store", eventToHandle.CreatedGoodsId);
            itemFacade.CreateItem(command);
        }
    }
}