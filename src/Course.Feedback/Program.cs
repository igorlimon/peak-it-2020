using Course.Common.Events;
using Course.Common.Services;

namespace Course.Feedback
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<CourseCompleted>()
                .Build()
                .Run();
        }
    }
}
