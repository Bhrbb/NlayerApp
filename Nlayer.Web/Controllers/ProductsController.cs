using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nlayer.Core.Dtos;
using Nlayer.Core.Models;
using Nlayer.Core.Services;
using Nlayer.Web.Services;

namespace Nlayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;

        public ProductsController(CategoryApiService categoryApiService, ProductApiService productApiService)
        {
            _categoryApiService = categoryApiService;
            _productApiService = productApiService;
        }

      
    //    private readonly IProductService _productService;
    //    private readonly ICategoryService _categoryService;
    //    private readonly IMapper _mapper;



    //    public ProductsController(IProductService productService, ICategoryService categoryService,IMapper mapper)
    //    {
    //        _productService = productService;
    //        _categoryService = categoryService;
    //        _mapper = mapper;
    //    }

        public async Task<IActionResult> Index()
        {
            var customResponse =(( await _productApiService.GetProductWithCategoriesAsync()));
            return View(customResponse);
        }

        public async Task<IActionResult> Save()
        {
            var categoriesDto = await _categoryApiService.GetAllAsync();
            //var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {

            if (ModelState.IsValid)
            {
                await _productApiService.SaveAsync(productDto);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryApiService.GetAllAsync();
            //var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var product=await _productApiService.GetByIdAsync(id);
            var categories=await _categoryApiService.GetAllAsync();
            //var categoriesDto=_mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories=new SelectList(categories, "Id", "Name",product.CategoryId);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult>Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.UpdateAsync(productDto);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryApiService.GetAllAsync();
            //var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            
            ViewBag.categories = new SelectList(categories, "Id", "Name",productDto.CategoryId);
            return View(productDto);

        }
        public async Task<IActionResult> Remove(int id)
        {
            await _productApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
