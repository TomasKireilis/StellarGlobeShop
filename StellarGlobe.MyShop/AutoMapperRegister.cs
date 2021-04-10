using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StellarGlobe.MyShop.GraphQl.ModelTypes.Models;
using StellarGlobe.MyShop.Models;

namespace StellarGlobe.MyShop
{
    public static class AutoMapperRegister
    {
        public static void RegisterAutoMapper(IServiceCollection service)
        {
            var configuration = new MapperConfigurationExpression();

            //Setup maps

            configuration.CreateMap<ProductDto, Product>();
            configuration.CreateMap<Product, ProductDto>();
            configuration.CreateMap<Shop, ShopDto>();
            configuration.CreateMap<ShopDto, Shop>();
            configuration.CreateMap<ProductType, ProductTypeDto>();
            configuration.CreateMap<ProductTypeDto, ProductType>();
            //----------------

            //Add service
            var mapperConfig = new MapperConfiguration(configuration);
            service.AddTransient<IMapper>(serv => new Mapper(mapperConfig));
            //----------------
        }
    }
}