using Framework.Core.Domain;

namespace Framework.Persistence.EF
{
    public abstract class AggregateRootMapping<T> : EntityMapping<T> where T : AggregateRoot
    {
    }
}