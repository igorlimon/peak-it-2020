using System;

namespace Course.Common.Events
{
    [Serializable()]
    public class NewCourseIsPublished : IEvent
    {
        public Guid CourseId { get; }
        public Guid UserId { get; }

        protected NewCourseIsPublished()
        {
        }

        public NewCourseIsPublished(Guid courseId, Guid userId)
        {
            CourseId = courseId;
            UserId = userId;
        }
    }
}