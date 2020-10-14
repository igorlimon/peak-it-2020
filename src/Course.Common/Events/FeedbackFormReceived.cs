using System;
using System.Collections.Generic;

namespace Course.Common.Events
{
    [Serializable()]
    public class FeedbackFormReceived : IEvent
    {
        public Guid FeedbackFormId { get; set; }
        public Guid CourseId { get; }
        public Guid UserId { get; }
        public IEnumerable<string> Questions { get; set; }

        protected FeedbackFormReceived()
        {
        }

        public FeedbackFormReceived(Guid feedbackFormId, Guid courseId, Guid userId, IEnumerable<string> questions)
        {
            FeedbackFormId = feedbackFormId;
            CourseId = courseId;
            UserId = userId;
            Questions = questions;
        }
    }
}
