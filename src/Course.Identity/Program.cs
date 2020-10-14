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
                .SubscribeToCommand<RegisterUserToCourse>()
                .SubscribeToCommand<SendMaterials>()
                .SubscribeToEvent<FeedbackSaved>()
                .SubscribeToEvent<FeedbackFormReceived>()
                .Build()
                .Run();
        }
    }
}
