using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nlayer.Core.Dtos;
using Nlayer.Core.Services;

namespace Nlayer.Api.Controllers
{
   
    public class CategoryiesController : CustomBaseController
    {

        private readonly ICategoryService _categoryservice;
        private readonly IMapper _mapper;
        public CategoryiesController(ICategoryService categoryservice, IMapper mapper)
        {
            _categoryservice = categoryservice;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories= await _categoryservice.GetAllAsync();
            var categorisDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Succes(200, categorisDto));
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            return CreateActionResult(await _categoryservice.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }
    }
}
