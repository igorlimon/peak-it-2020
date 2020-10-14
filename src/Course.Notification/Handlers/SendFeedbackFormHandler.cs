using System;
using System.Collections.Generic;
using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Feedback.Handlers
{
    public class SendFeedbackFormHandler : ICommandHandler<SendFeedbackForm>
    {
        private readonly IModel _channel;
        private readonly ILogger<SendFeedbackForm> _logger;

        public SendFeedbackFormHandler(
            IModel channel,
            ILogger<SendFeedbackForm> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(SendFeedbackForm command)
        {
            _logger.LogInformation($"3. Send feedback form userId:{command.UserId} courseId: {command.CourseId}");
            Guid feedbackFormId = Guid.NewGuid();
            var questions = new List<string> { "Did you find today's workshop useful?" };
            var @event = new FeedbackFormReceived(feedbackFormId, command.CourseId, command.UserId, questions);
            _channel.BasicPublish(exchange: "",
                routingKey: Extensions.GetEventQueueName<FeedbackFormReceived>(),
                basicProperties: null,
                body: @event.ObjectToByteArray());
        }
    }
}