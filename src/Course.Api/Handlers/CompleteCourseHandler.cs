using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Api.Handlers
{
    public class CompleteCourseHandler : ICommandHandler<CompleteCourse>
    {
        private readonly ILogger<CompleteCourse> _logger;
        private readonly IModel _channel;

        public CompleteCourseHandler(
            IModel channel,
            ILogger<CompleteCourse> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(CompleteCourse command)
        {
            _logger.LogInformation($"############ BEGIN ##############");
            _logger.LogInformation($"1. Complete course: {command.CourseId}");
            var @event = new CourseCompleted(command.CourseId, command.UserId);
            _channel.BasicPublish(exchange: "",
                routingKey: Extensions.GetEventQueueName<CourseCompleted>(),
                basicProperties: null,
                body: @event.ObjectToByteArray());
        }
    }
}