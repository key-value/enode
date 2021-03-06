﻿namespace ENode.Eventing.Impl
{
    /// <summary>The default implementation of IEventSynchronizer.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventSynchronizerWrapper<T> : IEventSynchronizer where T : class, IDomainEvent
    {
        private readonly IEventSynchronizer<T> _synchronizer;

        /// <summary>Parameterized constructor.
        /// </summary>
        /// <param name="synchronizer"></param>
        public EventSynchronizerWrapper(IEventSynchronizer<T> synchronizer)
        {
            _synchronizer = synchronizer;
        }

        /// <summary>Executed before persisting the event.
        /// </summary>
        /// <param name="evnt"></param>
        public void OnBeforePersisting(IDomainEvent evnt)
        {
            _synchronizer.OnBeforePersisting(evnt as T);
        }
        /// <summary>Executed after the event was persisted.
        /// </summary>
        /// <param name="evnt"></param>
        public void OnAfterPersisted(IDomainEvent evnt)
        {
            _synchronizer.OnAfterPersisted(evnt as T);
        }
        /// <summary>Represents the inner generic IEventSynchronizer.
        /// </summary>
        /// <returns></returns>
        public object GetInnerSynchronizer()
        {
            return _synchronizer;
        }
    }
}
