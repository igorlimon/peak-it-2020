using System;

namespace Course.Common.Events
{
    [Serializable()]
    public class CoursePublished : IEvent
    {
        public Guid CourseId { get; }
        public Guid UserId { get; }

        protected CoursePublished()
        {
        }

        public CoursePublished(Guid courseId, Guid userId)
        {
            CourseId = courseId;
            UserId = userId;
        }
    }
}
