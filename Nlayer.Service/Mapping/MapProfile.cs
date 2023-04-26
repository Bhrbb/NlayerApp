using AutoMapper;
using Nlayer.Core.Dtos;
using Nlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ProductDto, ProductEntity>().ReverseMap();
            CreateMap<CategoryDto, CategoryEntity>().ReverseMap();
            CreateMap<ProductFeature,ProductFeatureDto>().ReverseMap();
            CreateMap<ProductEntity, ProductWithCategory>();
            CreateMap<CategoryEntity, CategoryWithProductsDto>();

        }
    }
}
