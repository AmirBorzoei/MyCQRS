using Sales.SalesManagement.ApplicationService.Contract.Item;
using Sales.SalesManagement.Facade.Contract;

namespace Sales.SalesManagement.Facade
{
    public class ItemFacade : Framework.Core.Facade.Facade, IItemFacade
    {
        public void CreateItem(CreateItemCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}