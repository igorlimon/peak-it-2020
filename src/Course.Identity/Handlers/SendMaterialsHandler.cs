using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Identity.Handlers
{
    public class SendMaterialsHandler : ICommandHandler<SendMaterials>
    {
        private readonly ILogger<SendMaterials> _logger;
        private readonly IModel _channel;

        public SendMaterialsHandler(
            IModel channel,
            ILogger<SendMaterials> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(SendMaterials command)
        {
            _logger.LogInformation($"6.2. Send materials course: {command.CourseId}");
            string email = "test@test.com";
            var @event = new MaterialsReceived(command.CourseId, email, command.Materials);
            _channel.BasicPublish(exchange: "",
                routingKey: Extensions.GetEventQueueName<MaterialsReceived>(),
                basicProperties: null,
                body: @event.ObjectToByteArray());
        }
    }
}