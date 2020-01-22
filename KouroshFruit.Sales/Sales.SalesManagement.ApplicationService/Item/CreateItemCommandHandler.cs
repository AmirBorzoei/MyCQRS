using Framework.Core.CommandHandling;
using Framework.Core.Persistence;
using Sales.SalesManagement.ApplicationService.Contract.Item;
using Sales.SalesManagement.Domain.Item.Services;

namespace Sales.SalesManagement.ApplicationService.Item
{
    public class CreateItemCommandHandler : CommandHandler<CreateItemCommand>
    {
        private readonly IItemRepository itemRepository;

        public CreateItemCommandHandler(IDbContext dbContext, IItemRepository itemRepository) : base(dbContext)
        {
            this.itemRepository = itemRepository;
        }

        public override void Handle(CreateItemCommand command)
        {
            var newItem = Domain.Item.Item.CreateItem(command.Title, command.Description, command.GoodsId);
            itemRepository.Create(newItem);
        }
    }
}