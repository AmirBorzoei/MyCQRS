using Framework.Core.CommandHandling;
using Framework.Core.DependencyInjection;
using Framework.Core.Event;
using Framework.Core.Messaging;
using Framework.Core.Persistence;
using Framework.Messaging.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sales.SalesManagement.ApplicationService.Contract.Factor;
using Sales.SalesManagement.ApplicationService.Contract.Item;
using Sales.SalesManagement.ApplicationService.Factor;
using Sales.SalesManagement.ApplicationService.Item;
using Sales.SalesManagement.Domain.Factor.Services;
using Sales.SalesManagement.Domain.Item.Services;
using Sales.SalesManagement.Facade;
using Sales.SalesManagement.Facade.Contract;
using Sales.SalesManagement.Facade.Handlers;
using Sales.SalesManagement.Persistence.EF;
using Sales.SalesManagement.Persistence.EF.Factor;
using Sales.SalesManagement.Persistence.EF.Item;
using Store.StoreManagement.Domain.Contract.Goods;

namespace Sales.SalesManagement.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IBrokerBus, BrokerBus>();
            services.AddSingleton<IEventBus, EventAggregator>();

            services.AddSingleton<IContainer, Container>();
            services.AddSingleton<ICommandBus, CommandBus>();

            services.AddScoped<IDbContext, SalesDBContext>();

            services.AddScoped<IFactorFacade, FactorFacade>();
            services.AddScoped<IItemFacade, ItemFacade>();

            services.AddScoped<IFactorRepository, FactorRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddScoped<IEventHandler<GoodsCreatedEvent>, GoodsCreatedEventHandler>();

            services.AddScoped<ICommandHandler<CreateFactorCommand>, CreateFactorCommandHandler>();
            services.AddScoped<ICommandHandler<CreateItemCommand>, CreateItemCommandHandler>();

            var sp = services.BuildServiceProvider();
            var container = sp.GetService<IContainer>();
            ServiceLocator.Initial(container);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SubscribeBrokerHandlers();
        }

        private void SubscribeBrokerHandlers()
        {
            var eventAggregator = ServiceLocator.Current.Resolve<IEventBus>();
            var goodsCreatedEventHandler = ServiceLocator.Current.Resolve<IEventHandler<GoodsCreatedEvent>>();
            eventAggregator.Subscribe(goodsCreatedEventHandler);
        }
    }    
}