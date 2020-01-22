using Framework.Core.CommandHandling;
using Framework.Core.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Store.StoreManagement.ApplicationService.Contract;
using Store.StoreManagement.Domain.Goods.Services;
using System;

namespace Store.StoreManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsAPIController : ControllerBase
    {
        [HttpGet]
        public object Get(Guid? id)
        {
            System.Collections.Generic.List<IGoodsRepository> l = new System.Collections.Generic.List<IGoodsRepository>();
            for (int i = 0; i < 10000000; i++)
            {
                var goodsRepository2 = ServiceLocator.Current.Resolve<IGoodsRepository>();
                l.Add(goodsRepository2);
            }
            var goodsRepository = ServiceLocator.Current.Resolve<IGoodsRepository>();

            if (id.HasValue)
            {
                return goodsRepository.Get(id.Value);
            }

            return goodsRepository.GetAll();
        }

        [HttpPost]
        public void Post()
        {
            var createGoodsCommand = new CreateGoodsCommand("Table", 120, 80, 10, "Work Desk.", 10);

            var commandBus = ServiceLocator.Current.Resolve<ICommandBus>();
            commandBus.Dispatch(createGoodsCommand);
        }
    }
}