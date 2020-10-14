using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Api.Handlers
{
    public class PublishCourseHandler : ICommandHandler<PublishCourse>
    {
        private readonly ILogger<PublishCourse> _logger;
        private readonly IModel _channel;

        public PublishCourseHandler(
            IModel channel,
            ILogger<PublishCourse> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(PublishCourse command)
        {
            _logger.LogInformation($"############ BEGIN ##############");
            _logger.LogInformation($"1. Publish course: {command.CourseId}");
            var @event = new CoursePublished(command.CourseId, command.UserId);
            _channel.BasicPublish(exchange: "",
                routingKey: Extensions.GetEventQueueName<CoursePublished>(),
                basicProperties: null,
                body: @event.ObjectToByteArray());
        }
    }
}