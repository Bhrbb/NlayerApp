using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nlayer.Core.Services;

namespace Nlayer.Api.Controllers
{
   
    public class CategoryiesController : CustomBaseController
    {

        private readonly ICategoryService _categoryservice;
        public CategoryiesController(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            return CreateActionResult(await _categoryservice.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }
    }
}
