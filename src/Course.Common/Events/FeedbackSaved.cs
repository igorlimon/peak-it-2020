using System;

namespace Course.Common.Events
{
    [Serializable()]
    public class FeedbackSaved : IEvent
    {
        public Guid FeedbackId { get; set; }
        public Guid CourseId { get; }
        public Guid UserId { get; }

        protected FeedbackSaved()
        {
        }

        public FeedbackSaved(Guid feedbackId, Guid courseId, Guid userId)
        {
            FeedbackId = feedbackId;
            CourseId = courseId;
            UserId = userId;
        }
    }
}
