using System;
using System.Collections;
using System.Collections.Generic;


namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public interface IEventChannel
    {
        public void Subscribe<TEvent>(Action<TEvent> callback)
            where TEvent : IEvent;

        public void Unsubscribe<TEvent>(Action<TEvent> callback)
            where TEvent : IEvent;

        public void Publish<TEvent>(TEvent @event)
            where TEvent : IEvent;
    }
}
