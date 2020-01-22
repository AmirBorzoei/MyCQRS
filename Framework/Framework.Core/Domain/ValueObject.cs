using System;

namespace Framework.Core.Domain
{
    public abstract class ValueObject<TValueObject> : IEquatable<TValueObject>
    {
        public abstract bool Equals(TValueObject other);
    }
}
