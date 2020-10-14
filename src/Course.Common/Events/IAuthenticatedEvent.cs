using System;

namespace Course.Common.Events
{
    public interface IAuthenticatedEvent : IEvent
    {
         Guid UserId { get; }
    }
}