using System;

namespace Course.Common.Events
{
    [Serializable()]
    public class NotifyUserNewCourse : IEvent
    {
        public Guid CourseId { get; }
        public Guid UserId { get; }

        protected NotifyUserNewCourse()
        {
        }

        public NotifyUserNewCourse(Guid courseId, Guid userId)
        {
            CourseId = courseId;
            UserId = userId;
        }
    }
}
