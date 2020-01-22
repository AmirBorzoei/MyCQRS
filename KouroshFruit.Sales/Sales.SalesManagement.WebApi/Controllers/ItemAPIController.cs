using Framework.Core.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Sales.SalesManagement.Domain.Item.Services;
using System;

namespace Sales.SalesManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemAPIController : ControllerBase
    {
        [HttpGet]
        public object Get(Guid? id)
        {
            var itemRepository = ServiceLocator.Current.Resolve<IItemRepository>();

            if (id.HasValue)
            {
                return itemRepository.Get(id.Value);
            }

            return itemRepository.GetAll();
        }
    }
}