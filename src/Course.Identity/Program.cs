using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.Services;

namespace Course.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<FeedbackSaved>()
                .SubscribeToEvent<NotifyUserNewCourse>()
                .SubscribeToEvent<FeedbackFormReceived>()
                .SubscribeToEvent<NewCourseIsPublished>()
                .Build()
                .Run();
        }
    }
}
