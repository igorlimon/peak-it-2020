using System;
using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Feedback.Handlers
{
    public class CourseCompletedHandler : IEventHandler<CourseCompleted>
    {
        private readonly IModel _channel;
        private readonly ILogger<CourseCompleted> _logger;

        public CourseCompletedHandler(
            IModel channel,
            ILogger<CourseCompleted> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(CourseCompleted @event)
        {
            _logger.LogInformation($"2. Course completed: {@event.CourseId}");
            var command = new SendFeedbackForm(@event.CourseId, @event.UserId);
            _channel.BasicPublish(exchange: "",
                routingKey: Extensions.GetCommandQueueName<SendFeedbackForm>(),
                basicProperties: null,
                body: command.ObjectToByteArray());
        }
    }
}