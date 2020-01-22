using Framework.Core.Persistence;

namespace Framework.Core.CommandHandling
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected CommandHandler(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IDbContext DbContext { get; }

        public abstract void Handle(TCommand command);
    }
}