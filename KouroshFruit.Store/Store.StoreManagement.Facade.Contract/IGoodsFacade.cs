using Store.StoreManagement.ApplicationService.Contract;

namespace Store.StoreManagement.Facade.Contract
{
    public interface IGoodsFacade
    {
        void CreateGoods(CreateGoodsCommand command);
    }
}