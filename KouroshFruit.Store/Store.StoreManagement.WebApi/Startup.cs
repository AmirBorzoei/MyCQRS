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
using Store.StoreManagement.ApplicationService;
using Store.StoreManagement.ApplicationService.Contract;
using Store.StoreManagement.Domain.Goods.Services;
using Store.StoreManagement.Persistence.EF;
using Store.StoreManagement.Persistence.EF.Goods;
using static Store.StoreManagement.Domain.Goods.Goods;

namespace Store.StoreManagement.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IBrokerBus, BrokerBus>();
            services.AddSingleton<IEventBus, EventAggregator>();

            services.AddSingleton<IContainer, Container>();
            services.AddSingleton<ICommandBus, CommandBus>();

            services.AddScoped<IDbContext, StoreDBContext>();

            services.AddScoped<IGoodsRepository, GoodsRepository>();

            services.AddScoped<GoodsFactory, GoodsFactory>();

            services.AddScoped<ICommandHandler<CreateGoodsCommand>, CreateGoodsCommandHandler>();

            // Build the intermediate service provider
            var sp = services.BuildServiceProvider();
            var container = sp.GetService<IContainer>();
            ServiceLocator.Initial(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
        }
    }
}