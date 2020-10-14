using System;

namespace Course.Common.Commands
{
    [Serializable()]
    public class RegisterUserToCourse: ICommand
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }

        protected RegisterUserToCourse()
        {
        }

        public RegisterUserToCourse(Guid courseId, Guid userId)
        {
            CourseId = courseId;
            UserId = userId;
        }
    }
}