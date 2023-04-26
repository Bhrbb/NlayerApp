using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nlayer.Core.Dtos;
using Nlayer.Core.Models;
using Nlayer.Core.Services;

namespace Nlayer.Api.Controllers
{
    
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<ProductEntity> _services;
        private readonly IProductService _productservice;
        public ProductController(IMapper mapper, IService<ProductEntity> services, IProductService productservice)
        {
            _mapper = mapper;
            _services = services;
            _productservice = productservice;

        }
        //get api /products/GetProductWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory()
        {
            return CreateActionResult(await _productservice.GetProductWithCategory());
          
        }

        //get api/products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _services.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            // return Ok(CustomResponseDto<List<ProductDto>>.Succes(200, productDtos));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Succes(200, productDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _services.GetByIdAsync(id);
            var productDtos = _mapper.Map<ProductDto>(products);
            return CreateActionResult(CustomResponseDto<ProductDto>.Succes(200, productDtos));
        }
        [HttpPost()]
        public async Task<IActionResult> Save(ProductDto product)
        {
            var products = await _services.AddAsync(_mapper.Map<ProductEntity>(product));
            var productDtos = _mapper.Map<ProductDto>(products);
            return CreateActionResult(CustomResponseDto<ProductDto>.Succes(201, productDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductDto product)
        {
             await _services.UpdateAsync(_mapper.Map<ProductEntity>(product));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _services.GetByIdAsync(id);
             await _services.RemoveAsync(product);
       
            return CreateActionResult(CustomResponseDto<ProductDto>.Succes(204));
        }
    }
}
