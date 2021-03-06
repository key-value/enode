﻿using System;
using ENode.Domain;
using NoteSample.DomainEvents;

namespace NoteSample.Domain
{
    [Serializable]
    public class Note : AggregateRoot<string>
    {
        public string Title { get; private set; }

        public Note(string id, string title) : base(id)
        {
            RaiseEvent(new NoteCreatedEvent(Id, title));
        }

        public void ChangeTitle(string title)
        {
            RaiseEvent(new NoteTitleChangedEvent(Id, title));
        }

        private void Handle(NoteCreatedEvent evnt)
        {
            Id = evnt.AggregateRootId;
            Title = evnt.Title;
        }
        private void Handle(NoteTitleChangedEvent evnt)
        {
            Title = evnt.Title;
        }
    }
}
