using Course.Common.Events;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Notification.Handlers
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
            _logger.LogInformation($"6. Feedback saved: {@event.FeedbackId}");
            _logger.LogInformation($"############ END ##############");
        }
    }
}