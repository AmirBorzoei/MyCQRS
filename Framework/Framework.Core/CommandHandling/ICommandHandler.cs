using Framework.Core.Persistence;

namespace Framework.Core.CommandHandling
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        IDbContext DbContext { get; }

        void Handle(TCommand command);
    }
}