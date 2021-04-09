using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StellarGlobe.MyShop.BackgroundServices.DomainHandlers;
using StellarGlobe.MyShop.BackgroundServices.DomainHandlers.Interfaces;
using StellarGlobe.MyShop.BackgroundServices.MessageBusHanders;
using StellarGlobe.MyShop.Models;
using StellarGlobe.MyShop.Services.MessageBus.RabbitMQ;

namespace StellarGlobe.MyShop
{
    public static class AutoMapperRegister
    {
        public static void RegisterAutoMapper(IServiceCollection service)
        {
            var configuration = new MapperConfigurationExpression();

            //Setup maps

            configuration.CreateMap<ProductDTO, Product>();
            configuration.CreateMap<Product, ProductDTO>();
            configuration.CreateMap<Shop, ShopDTO>();
            configuration.CreateMap<ShopDTO, Shop>();
            configuration.CreateMap<ProductType, ProductTypeDTO>();
            configuration.CreateMap<ProductTypeDTO, ProductType>();
            //----------------

            //Add service
            var mapperConfig = new MapperConfiguration(configuration);
            service.AddTransient<IMapper>(serv => new Mapper(mapperConfig));
            //----------------
        }
    }
}