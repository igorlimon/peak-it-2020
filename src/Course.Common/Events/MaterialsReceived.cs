using System;
using System.Collections.Generic;

namespace Course.Common.Events
{
    [Serializable()]
    public class MaterialsReceived : IEvent
    {
        public Guid CourseId { get; }
        public string Email { get; }
        public List<string> Materials { get; set; }

        protected MaterialsReceived()
        {
        }

        public MaterialsReceived(Guid courseId, string email, List<string> materials)
        {
            CourseId = courseId;
            Email = email;
            Materials = materials;
        }
    }
}
