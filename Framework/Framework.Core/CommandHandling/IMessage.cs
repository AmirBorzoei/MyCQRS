using System;

namespace Framework.Core.CommandHandling
{
    public interface IMessage
    {
        DateTime TimeStamp { get; }
    }
}