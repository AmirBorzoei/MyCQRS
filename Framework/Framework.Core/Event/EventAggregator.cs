using Framework.Core.Messaging;

namespace Framework.Core.Event
{
    public class EventAggregator : IEventBus
    {
        private readonly IBrokerBus brokerBus;

        public EventAggregator(IBrokerBus brokerBus)
        {
            this.brokerBus = brokerBus;
        }

        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            brokerBus.Subscribe(eventHandler);
        }

        public void Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent
        {
            brokerBus.Publish(eventToPublish);
        }
    }
}