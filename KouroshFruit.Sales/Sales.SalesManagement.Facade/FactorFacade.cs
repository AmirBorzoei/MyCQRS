using Sales.SalesManagement.ApplicationService.Contract.Factor;
using Sales.SalesManagement.Facade.Contract;

namespace Sales.SalesManagement.Facade
{
    public class FactorFacade : Framework.Core.Facade.Facade, IFactorFacade
    {
        public void CreateFactor(CreateFactorCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}