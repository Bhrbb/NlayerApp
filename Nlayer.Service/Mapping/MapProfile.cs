using AutoMapper;
using Nlayer.Core.Dtos;
using Nlayer.Core.Models;

namespace Nlayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductDto, ProductEntity>().ReverseMap();
            CreateMap<CategoryDto, CategoryEntity>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductEntity, ProductWithCategory>();
            CreateMap<CategoryEntity, CategoryWithProductsDto>();

        }
    }
}
