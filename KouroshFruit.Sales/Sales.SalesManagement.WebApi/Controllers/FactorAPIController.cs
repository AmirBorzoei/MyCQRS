using Framework.Core.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Sales.SalesManagement.ApplicationService.Contract.Factor;
using Sales.SalesManagement.Domain.Factor;
using Sales.SalesManagement.Domain.Factor.Services;
using Sales.SalesManagement.Facade.Contract;
using System;
using System.Collections.Generic;

namespace Sales.SalesManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactorAPIController : ControllerBase
    {
        [HttpGet]
        public object Get(Guid? id)
        {
            var factorRepository = ServiceLocator.Current.Resolve<IFactorRepository>();

            if (id.HasValue)
            {
                return factorRepository.Get(id.Value);
            }

            return factorRepository.GetAll();
        }

        [HttpPost]
        public void Post()
        {
            var factorItems = new List<FactorItem> {
                FactorItem.CreateFactorItem(Guid.Empty, Guid.Empty, 10)
            };
            var createFactorCommand = new CreateFactorCommand(System.DateTime.Now.AddDays(7), "Factor", "-", factorItems);

            var factorFacade = ServiceLocator.Current.Resolve<IFactorFacade>();
            factorFacade.CreateFactor(createFactorCommand);
        }
    }
}