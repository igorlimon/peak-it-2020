using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.Services;

namespace Course.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<PublishCourse>()
                .SubscribeToCommand<CompleteCourse>()
                .SubscribeToCommand<SaveFeedback>()
                .SubscribeToEvent<UserRegisteredToCourse>()
                .Build()
                .Run();
        }
    }
}
