namespace Framework.Core.Event
{
    public interface IEventBus
    {
        void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;

        void Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent;
    }
}