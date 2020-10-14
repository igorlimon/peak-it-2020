using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Notification.Handlers
{
    public class CoursePublishedHandler : IEventHandler<CoursePublished>
    {
        private readonly IModel _channel;
        private readonly ILogger<CoursePublished> _logger;

        public CoursePublishedHandler(
            IModel channel,
            ILogger<CoursePublished> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(CoursePublished @event)
        {
            _logger.LogInformation($"2. Course published: {@event.CourseId}");
            var command = new RegisterUserToCourse(@event.CourseId, @event.UserId);
            _channel.BasicPublish(exchange: "",
                routingKey: Extensions.GetCommandQueueName<RegisterUserToCourse>(),
                basicProperties: null,
                body: command.ObjectToByteArray());
        }
    }
}