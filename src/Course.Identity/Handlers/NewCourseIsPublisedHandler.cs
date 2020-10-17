using System.Threading.Tasks;
using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Course.Identity.Handlers
{
    public class NewCourseIsPublishedHandler : IEventHandler<NewCourseIsPublished>
    {
        private readonly IModel _channel;
        private readonly ILogger<NewCourseIsPublished> _logger;

        public NewCourseIsPublishedHandler(
            IModel channel,
            ILogger<NewCourseIsPublished> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(NewCourseIsPublished @event)
        {
            _logger.LogInformation($"3. User :{@event.UserId} was notified about new course: {@event.CourseId}");
            var command = new RegisterUserToCourse(@event.CourseId, @event.UserId);
            _channel.BasicPublish(exchange: "",
                    routingKey: Extensions.GetCommandQueueName<RegisterUserToCourse>(),
                    basicProperties: null,
                    body: command.ObjectToByteArray());
        }
    }
}