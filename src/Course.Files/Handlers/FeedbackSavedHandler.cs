using Course.Common.Events;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;
using Course.Common.RabbitMq;
using Course.Common.Commands;
using System.Collections.Generic;
using System;

namespace Course.Files.Handlers
{
    public class FeedbackSavedHandler : IEventHandler<FeedbackSaved>
    {
        private readonly IModel _channel;
        private readonly ILogger<FeedbackSaved> _logger;

        public FeedbackSavedHandler(
            IModel channel,
            ILogger<FeedbackSaved> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(FeedbackSaved @event)
        {
            _logger.LogInformation($"6.1 Materials sent: {@event.FeedbackId} Course id:{@event.CourseId} UserId : {@event.UserId}");

            var feedbackId = Guid.NewGuid();
            var materials = new List<string> { "Presentation" };
            var command = new SendMaterials(@event.CourseId, @event.UserId, feedbackId, materials);
            _channel.BasicPublish(exchange: "",
                routingKey: Extensions.GetCommandQueueName<SendMaterials>(),
                basicProperties: null,
                body: command.ObjectToByteArray());
        }
    }
}
