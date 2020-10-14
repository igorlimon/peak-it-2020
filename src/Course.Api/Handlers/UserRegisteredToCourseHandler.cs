using Course.Common.Events;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace Course.Api.Handlers
{
    public class UserRegisteredToCourseHandler : IEventHandler<UserRegisteredToCourse>
    {
        private readonly IModel _channel;
        private readonly ILogger<UserRegisteredToCourse> _logger;

        public UserRegisteredToCourseHandler(
            IModel channel,
            ILogger<UserRegisteredToCourse> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public async Task HandleAsync(UserRegisteredToCourse @event)
        {
            _logger.LogInformation($"4. User registered {@event.UserId} to course: {@event.CourseId}");
            _logger.LogInformation($"############ END ##############");
        }
    }
}