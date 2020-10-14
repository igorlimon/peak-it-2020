using System;

namespace Course.Common.Events
{
    [Serializable()]
    public class UserRegisteredToCourse : IEvent
    {
        public Guid CourseId { get; }
        public Guid UserId { get; }

        protected UserRegisteredToCourse()
        {
        }

        public UserRegisteredToCourse(Guid courseId, Guid userId)
        {
            CourseId = courseId;
            UserId = userId;
        }
    }
}
