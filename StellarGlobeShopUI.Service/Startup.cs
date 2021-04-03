using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQLibrary;
using RabbitMQLibrary.Interfaces;
using StellarGlobeShopUI.Service.GraphQl;
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
            //RabbitMQ messageBus
            services.AddSingleton<ConnectionFactory>();
            services.AddAuthorization();
            services.AddSingleton<IRabbitMQClient, RabbitMqClient>(x =>
                new RabbitMqClient(x.GetService<ConnectionFactory>(),
                    GetRabbitMqConnectionData(),
                    x.GetService<ILogger<RabbitMqClient>>()));

            services.AddScoped<IMessageBus, RabbitMQMessageBus>();
            //GraphQL
            GraphQLCServiceConfigurator.SetUpGraphQLDependencies(services);
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
                endpoints.MapGraphQL();
            });
            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql-voyager"
            });
        }

        public RabbitMqConnectionData GetRabbitMqConnectionData()
        {
            return new RabbitMqConnectionData(Configuration["RabbitMQ:Username"],
                Configuration["RabbitMQ:Password"],
                Configuration["RabbitMQ:VirtualHost"],
                Configuration["RabbitMQ:Host"],
                int.Parse(Configuration["RabbitMQ:Port"])

                );
        }
    }
}