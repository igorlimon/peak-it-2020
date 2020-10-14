using Course.Common.Events;
using Course.Common.Services;

namespace Course.Files
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<FeedbackSaved>()
                .Build()
                .Run();
        }
    }
}
