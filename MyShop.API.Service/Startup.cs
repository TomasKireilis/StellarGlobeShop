using System.Reflection;
using GraphQL.Server.Ui.Voyager;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyShop.API.Service.StartupServicesConfiguration;
using RabbitMQ.Client;
using RabbitMQLibrary;
using RabbitMQLibrary.Interfaces;

namespace MyShop.API.Service
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

            services.AddSingleton<IRabbitMQClient, RabbitMqClient>(x =>
                new RabbitMqClient(x.GetService<ConnectionFactory>(),
                    GetRabbitMqConnectionData(),
                    x.GetService<ILogger<RabbitMqClient>>()));

            services.AddTransient<IMessageBus, RabbitMQMessageBus>();

            services.AddPooledDbContextFactory<MyShopContext>(opt => opt.UseSqlServer(Configuration["DbContext:ConnectionString"]));
            services.AddTransient<MyShopDataSeeder>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            //AutoMapper
            AutoMapperRegister.RegisterAutoMapper(services);

            //GraphQL
            GraphQLCServiceConfigurator.SetUpGraphQLDependencies(services);

            //MessageBroker
            MessageHandlersRegister.RegisterMessageHandlers(services);
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
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