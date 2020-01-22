using System;

namespace Framework.Core.Domain
{
    public interface IPersistableObject
    {
        Guid Id { get; }

        DateTime CreatedDate { get; set; }

        DateTime? LastChangedDate { get; set; }

        string CreatedBy { get; set; }

        string LastChangedBy { get; set; }
    }
}
