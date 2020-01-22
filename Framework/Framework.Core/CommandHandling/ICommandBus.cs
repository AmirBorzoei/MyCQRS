namespace Framework.Core.CommandHandling
{
    public interface ICommandBus
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}