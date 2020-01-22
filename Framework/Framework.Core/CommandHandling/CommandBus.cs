using Framework.Core.DependencyInjection;

namespace Framework.Core.CommandHandling
{
    public class CommandBus : ICommandBus
    {
        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = ServiceLocator.Current.Resolve<ICommandHandler<TCommand>>();
            var commandHandlerWithTransactionDecorator = new TransactionalDecorator<TCommand>(commandHandler);
            commandHandlerWithTransactionDecorator.Handle(command);
        }
    }
}