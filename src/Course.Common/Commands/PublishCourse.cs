using System;

namespace Course.Common.Commands
{
    [Serializable()]
    public class PublishCourse : ICommand
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }

        protected PublishCourse()
        {
        }

        public PublishCourse(Guid courseId, Guid userId)
        {
            CourseId = courseId;
            UserId = userId;
        }
    }
}