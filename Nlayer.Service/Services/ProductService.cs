using AutoMapper;
using Nlayer.Core.Dtos;
using Nlayer.Core.IUnitOfWork;
using Nlayer.Core.Models;
using Nlayer.Core.Repositories;
using Nlayer.Core.Services;
using System.Collections.Generic;

namespace Nlayer.Service.Services
{
    public class ProductService : Service<ProductEntity>, IProductService
    {
        private readonly IProductRepository _productrepository;

        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<ProductEntity> repository, IUnitOFWork unitOfWork, IProductRepository productrepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productrepository = productrepository;

        }

        public async Task<CustomResponseDto<List<ProductWithCategory>>> GetProductWithCategory()
        {
            var products = await _productrepository.GetProductWithCategory();
            var productsDto = _mapper.Map<List<ProductWithCategory>>(products);
            return CustomResponseDto < List < ProductWithCategory >>.Succes(200,productsDto);


        }


    }
}
