using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Api.Handlers
{
    public class SaveFeedbackHandler : ICommandHandler<SaveFeedback>
    {
        private readonly ILogger<SaveFeedback> _logger;
        private readonly IModel _channel;

        public SaveFeedbackHandler(
            IModel channel,
            ILogger<SaveFeedback> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(SaveFeedback command)
        {
            _logger.LogInformation($"5. Save feedback: {command.FeedbackId} with answers: {string.Concat(command.Answers)}");
            var @event = new FeedbackSaved(command.FeedbackId, command.CourseId, command.UserId);
            _channel.BasicPublish(exchange: "",
                routingKey: Extensions.GetEventQueueName<FeedbackSaved>(),
                basicProperties: null,
                body: @event.ObjectToByteArray());
        }
    }
}