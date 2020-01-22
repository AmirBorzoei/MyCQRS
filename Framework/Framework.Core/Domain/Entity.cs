using System;

namespace Framework.Core.Domain
{
    public abstract class Entity : IPersistableObject, IEquatable<Entity>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        public byte[] RowVersion { get; set; }

        public bool Equals(Entity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastChangedDate { get; set; }

        public string CreatedBy { get; set; }

        public string LastChangedBy { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Entity)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
