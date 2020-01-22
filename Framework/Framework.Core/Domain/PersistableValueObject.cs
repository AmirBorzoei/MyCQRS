using System;

namespace Framework.Core.Domain
{
    public abstract class PersistableValueObject<TValueObject> : ValueObject<TValueObject>, IPersistableObject
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastChangedDate { get; set; }

        public string CreatedBy { get; set; }

        public string LastChangedBy { get; set; }
    }
}
