using AutoMapper;
using ProductService.API.Dtos;
using ProductService.API.Models;

namespace ProductService.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));
                config.CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));
            });

            return mappingConfig;
        }
    }
}
