using System;
using System.Collections.Generic;

namespace Course.Common.Commands
{
    [Serializable()]
    public class SaveFeedback : ICommand
    {
        public Guid FeedbackId { get; set; }
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<string> Answers { get; set; }

        protected SaveFeedback()
        {
        }

        public SaveFeedback(Guid feedbackId, Guid courseId, Guid userId, IEnumerable<string> answers)
        {
            FeedbackId = feedbackId;
            CourseId = courseId;
            UserId = userId;
            Answers = answers;
        }
    }
}