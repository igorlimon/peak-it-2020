using System;

namespace Course.Common.Commands
{
    [Serializable()]
    public class CompleteCourse : ICommand
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }

        protected CompleteCourse()
        {
        }

        public CompleteCourse(Guid courseId, Guid userId)
        {
            CourseId = courseId;
            UserId = userId;
        }
    }
}
