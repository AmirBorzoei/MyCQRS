using Sales.SalesManagement.ApplicationService.Contract.Item;

namespace Sales.SalesManagement.Facade.Contract
{
    public interface IItemFacade
    {
        void CreateItem(CreateItemCommand command);
    }
}
