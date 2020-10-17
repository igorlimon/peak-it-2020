using System.Threading.Tasks;
using Course.Common.Events;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Course.Identity.Handlers
{
    public class FeedbackSavedHandler : IEventHandler<FeedbackSaved>
    {
        private readonly ILogger<FeedbackSaved> _logger;

        public FeedbackSavedHandler(
            ILogger<FeedbackSaved> logger)
        {
            _logger = logger;
        }

        public async Task HandleAsync(FeedbackSaved @event)
        {
            _logger.LogInformation($"6.1. Feedback saved: {@event.FeedbackId}. Trainer received feedback.");
            _logger.LogInformation($"############ END ##############");
        }
    }
}