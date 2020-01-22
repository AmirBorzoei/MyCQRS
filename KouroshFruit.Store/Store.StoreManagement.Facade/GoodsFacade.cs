using Store.StoreManagement.ApplicationService.Contract;
using Store.StoreManagement.Facade.Contract;

namespace Store.StoreManagement.Facade
{
    public class GoodsFacade : Framework.Core.Facade.Facade, IGoodsFacade
    {
        public void CreateGoods(CreateGoodsCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}