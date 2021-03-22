using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQLibrary;
using RabbitMQLibrary.Interfaces;
using StellarGlobeShopUI.Service.Services.MessageBus.RabbitMQ;

namespace StellarGlobeShopUI.Service
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
            services.AddControllers();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );

            //RabbitMQ messageBus
            services.AddSingleton<ConnectionFactory>();
            services.AddSingleton<IRabbitMQClient, RabbitMqClient>(x =>
                new RabbitMqClient(x.GetService<ConnectionFactory>(), GetRabbitMqConnectionData(), x.GetService<ILogger<RabbitMqClient>>()));

            services.AddScoped<IMessageBus, RabbitMQMessageBus>();

            //GraphQL
            GraphQLCServiceConfigurator.SetUpGraphQLDependencies(services);

            //BackgroundWorkers
            services.AddHostedService<RabbitMQSubscriber>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
        }

        public RabbitMqConnectionData GetRabbitMqConnectionData()
        {
            return new RabbitMqConnectionData("guest", "guest", "/", "localhost");
        }
    }
}