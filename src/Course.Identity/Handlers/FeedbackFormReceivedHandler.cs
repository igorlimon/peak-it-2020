using System;
using System.Collections.Generic;
using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Identity.Handlers
{
    public class FeedbackFormReceivedHandler : IEventHandler<FeedbackFormReceived>
    {
        private readonly IModel _channel;
        private readonly ILogger<FeedbackFormReceived> _logger;

        public FeedbackFormReceivedHandler(
            IModel channel,
            ILogger<FeedbackFormReceived> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(FeedbackFormReceived @event)
        {
            _logger.LogInformation($"4. Feedback form received: {@event.FeedbackFormId} with questions:{string.Concat(@event.Questions)}");
            var feedbackId = Guid.NewGuid();
            var answers = new List<string> { "Very usefull" };
            var command = new SaveFeedback(feedbackId,  @event.CourseId, @event.UserId, answers);
            _channel.BasicPublish(exchange: "",
                routingKey: Extensions.GetCommandQueueName<SaveFeedback>(),
                basicProperties: null,
                body: command.ObjectToByteArray());
        }
    }
}