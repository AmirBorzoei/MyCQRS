using System;

namespace Framework.Core.Event
{
    [Serializable]
    public abstract class Event : IEvent
    {
        protected Event()
        {
            TimeStamp = DateTime.Now;
        }

        public DateTime TimeStamp { get; }
    }
}