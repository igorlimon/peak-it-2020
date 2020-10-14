using System;

namespace Course.Common.Commands
{
    [Serializable()]
    public class SendFeedbackForm : ICommand
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }

        protected SendFeedbackForm()
        {
        }

        public SendFeedbackForm(Guid courseId, Guid userId)
        {
            CourseId = courseId;
            UserId = userId;
        }
    }
}