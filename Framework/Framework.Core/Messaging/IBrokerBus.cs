using Framework.Core.Event;

namespace Framework.Core.Messaging
{
    public interface IBrokerBus
    {
        void Publish<TEvent>(TEvent message) where TEvent : IEvent;

        void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;
    }
}