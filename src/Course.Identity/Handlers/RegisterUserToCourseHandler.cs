using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Notification.Handlers
{
    public class RegisterUserToCourseHandler : ICommandHandler<RegisterUserToCourse>
    {
        private readonly IModel _channel;
        private readonly ILogger<RegisterUserToCourse> _logger;

        public RegisterUserToCourseHandler(
            IModel channel,
            ILogger<RegisterUserToCourse> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(RegisterUserToCourse command)
        {
            _logger.LogInformation($"3. Register user :{command.UserId} to course: {command.CourseId}");
            var @event = new UserRegisteredToCourse(command.CourseId, command.UserId);
            _channel.BasicPublish(exchange: "",
                routingKey: Extensions.GetEventQueueName<UserRegisteredToCourse>(),
                basicProperties: null,
                body: @event.ObjectToByteArray());
        }
    }
}