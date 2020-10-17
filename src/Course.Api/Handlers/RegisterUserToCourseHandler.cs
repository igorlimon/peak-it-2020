using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Api.Handlers
{
    public class RegisterUserToCourseHandler : ICommandHandler<RegisterUserToCourse>
    {
        private readonly ILogger<RegisterUserToCourse> _logger;
        private readonly IModel _channel;

        public RegisterUserToCourseHandler(
            IModel channel,
            ILogger<RegisterUserToCourse> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(RegisterUserToCourse command)
        {
            _logger.LogInformation($"4. Register user: {command.UserId} to the course: {command.CourseId}");
            _logger.LogInformation($"############ END ##############");
        }
    }
}