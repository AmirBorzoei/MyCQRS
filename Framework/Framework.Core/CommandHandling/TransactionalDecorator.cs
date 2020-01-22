using Framework.Core.Persistence;

namespace Framework.Core.CommandHandling
{
    public class TransactionalDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> commandHandler;

        public TransactionalDecorator(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
            DbContext = commandHandler.DbContext;
        }

        public IDbContext DbContext { get; }

        public void Handle(TCommand command)
        {
            commandHandler.Handle(command);
            DbContext.SaveChanges();
        }
    }
}