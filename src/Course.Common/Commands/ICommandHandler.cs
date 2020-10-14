using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Course.Common.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
         Task HandleAsync(T command);
    }
}