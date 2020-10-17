using Course.Common.Auth;
using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.Mongo;
using Course.Common.RabbitMq;
using Course.Identity.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Course.Identity
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
            services.AddJwt(Configuration);
            services.AddMongoDB(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddSingleton<IEventHandler<NewCourseIsPublished>, NewCourseIsPublishedHandler>();
            services.AddSingleton<IEventHandler<FeedbackFormReceived>, FeedbackFormReceivedHandler>();
            services.AddSingleton<IEventHandler<FeedbackSaved>, FeedbackSavedHandler>();
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
