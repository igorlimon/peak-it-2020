using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Notification.Handlers
{
    public class MaterialsReceivedHandler : IEventHandler<MaterialsReceived>
    {
        private readonly ILogger<MaterialsReceived> _logger;

        public MaterialsReceivedHandler(
            ILogger<MaterialsReceived> logger)
        {
            _logger = logger;
        }

        public async Task HandleAsync(MaterialsReceived @event)
        {
            _logger.LogInformation($"6.3. Materials received: {@event.CourseId}");
            _logger.LogInformation($"##########################END##########################");
        }
    }
}