using Framework.Core.CommandHandling;
using Framework.Core.DependencyInjection;

namespace Framework.Core.Facade
{
    public abstract class Facade
    {
        protected ICommandBus CommandBus
        {
            get
            {
                return ServiceLocator.Current.Resolve<ICommandBus>();
            }
        }
    }
}
