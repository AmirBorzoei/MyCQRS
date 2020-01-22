using Framework.Core.CommandHandling;
using Framework.Core.Persistence;
using Store.StoreManagement.ApplicationService.Contract;
using Store.StoreManagement.Domain.Goods.Services;
using static Store.StoreManagement.Domain.Goods.Goods;

namespace Store.StoreManagement.ApplicationService
{
    public class CreateGoodsCommandHandler : CommandHandler<CreateGoodsCommand>
    {
        private readonly GoodsFactory goodsFactory;
        private readonly IGoodsRepository goodsRepository;


        public CreateGoodsCommandHandler(IDbContext dbContext, GoodsFactory goodsFactory, IGoodsRepository goodsRepository) : base(dbContext)
        {
            this.goodsFactory = goodsFactory;
            this.goodsRepository = goodsRepository;
        }

        public override void Handle(CreateGoodsCommand command)
        {
            var newCustomer = goodsFactory.CreateGoods(command.Title, command.Length, command.Width, command.Weight, command.Description, command.NumberOfInventory);
            goodsRepository.Create(newCustomer);
        }
    }
}