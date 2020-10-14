using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.Mongo;
using Course.Common.RabbitMq;
using Course.Feedback.Handlers;
using Course.Notification.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Course.Notification
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddRabbitMq(Configuration);
            services.AddMongoDB(Configuration);
            services.AddSingleton<IEventHandler<CoursePublished>, CoursePublishedHandler>(); 
            services.AddSingleton<IEventHandler<MaterialsReceived>, MaterialsReceivedHandler>();
            services.AddSingleton<ICommandHandler<SendFeedbackForm>, SendFeedbackFormHandler>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseMvc();
        }
    }
}
