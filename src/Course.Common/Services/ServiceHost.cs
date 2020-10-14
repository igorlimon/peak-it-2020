using System;
using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Course.Common.Services
{
    public class ServiceHost : IServiceHost
    {
        private readonly IWebHost _webHost;

        public ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }

        public void Run() => _webHost.Run();

        public static HostBuilder Create<TStartup>(string[] args) where TStartup : class
        {
            Console.Title = typeof(TStartup).Namespace;
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<TStartup>();

            return new HostBuilder(webHostBuilder.Build());
        }

        public abstract class BuilderBase 
        {
            public abstract ServiceHost Build();
        }

        public class HostBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private IModel _model;

            public HostBuilder(IWebHost webHost)
            {
                _webHost = webHost;
            }

            public ModelBuilder UseRabbitMq()
            {
                _model = (IModel)_webHost.Services.GetService(typeof(IModel));

                return new ModelBuilder(_webHost, _model);
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }

        public class ModelBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private IModel _model;

            public ModelBuilder(IWebHost webHost, IModel model)
            {
                _webHost = webHost;
                _model = model;
            }

            public ModelBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
            {
                var handler = (ICommandHandler<TCommand>)_webHost.Services
                    .GetService(typeof(ICommandHandler<TCommand>));
                _model.WithCommandHandlerAsync(handler);

                return this;
            }

            public ModelBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                var handler = (IEventHandler<TEvent>)_webHost.Services
                    .GetService(typeof(IEventHandler<TEvent>));
                _model.WithEventHandlerAsync(handler);

                return this;
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }
    }
}