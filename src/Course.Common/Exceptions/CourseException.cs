using System;

namespace Course.Common.Exceptions
{
    public class CourseException : Exception
    {
        public string Code { get; }

        public CourseException()
        {
        }

        public CourseException(string code)
        {
            Code = code;
        }

        public CourseException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public CourseException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public CourseException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public CourseException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }        
    }
}