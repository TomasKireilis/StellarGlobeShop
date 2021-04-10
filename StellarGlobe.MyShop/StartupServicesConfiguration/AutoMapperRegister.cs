using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StellarGlobe.MyShop.Application.BackgroundServices.MessageBusHanders;
using StellarGlobe.MyShop.GraphQl.GraphQLModels.InputModels;

namespace StellarGlobe.MyShop.StartupServicesConfiguration
{
    public static class AutoMapperRegister
    {
        public static void RegisterAutoMapper(IServiceCollection service)
        {
            var configuration = new MapperConfigurationExpression();

            //Setup maps

            //----------------

            //Add service
            var mapperConfig = new MapperConfiguration(configuration);
            service.AddTransient<IMapper>(serv => new Mapper(mapperConfig));
            //----------------
        }
    }
}