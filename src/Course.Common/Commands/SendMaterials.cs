using System;
using System.Collections.Generic;
using System.Linq;

namespace Course.Common.Commands
{
    [Serializable()]
    public class SendMaterials : ICommand
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
        public Guid FeedbackId { get; set; }
        public List<string> Materials { get; set; }

        protected SendMaterials()
        {
        }

        public SendMaterials(Guid courseId, Guid userId, Guid feedbackId, IEnumerable<string> materials)
        {
            CourseId = courseId;
            UserId = userId;
            FeedbackId = feedbackId;
            Materials = materials.ToList();
        }
    }
}