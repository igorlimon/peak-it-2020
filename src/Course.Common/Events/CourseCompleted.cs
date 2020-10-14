using System;

namespace Course.Common.Events
{
    [Serializable()]
    public class CourseCompleted : IEvent
    {
        public Guid CourseId { get; }
        public Guid UserId { get; }

        protected CourseCompleted()
        {
        }

        public CourseCompleted(Guid courseId, Guid userId)
        {
            CourseId = courseId;
            UserId = userId;
        }
    }
}
