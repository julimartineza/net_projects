using System;
using System.Collections;
using System.Collections.Generic;
using UCR.ECCI.PI.frontend.Unity.Domain;
using Zenject;


namespace UCR.ECCI.PI.frontend.Unity.Infrastructure
{
    public class SignalEventChannel : IEventChannel
    {
        private readonly SignalBus _signalBus;

        public SignalEventChannel(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Publish<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            _signalBus.Fire(@event);
        }

        public void Subscribe<TEvent>(Action<TEvent> callback)
            where TEvent : IEvent
        {
            _signalBus.Subscribe(callback);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> callback)
            where TEvent : IEvent
        {
            _signalBus.Unsubscribe(callback);
        }
    }
}
