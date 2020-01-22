namespace Framework.Core.Event
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        void Handle(TEvent eventToHandle);
    }
}
