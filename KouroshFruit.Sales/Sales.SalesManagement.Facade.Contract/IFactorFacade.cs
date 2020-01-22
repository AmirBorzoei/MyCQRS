using Sales.SalesManagement.ApplicationService.Contract.Factor;

namespace Sales.SalesManagement.Facade.Contract
{
    public interface IFactorFacade
    {
        void CreateFactor(CreateFactorCommand command);
    }
}
