﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nlayer.Core.Dtos;
using Nlayer.Core.Models;
using Nlayer.Core.Services;

namespace Nlayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;



        public ProductsController(IProductService productService, ICategoryService categoryService,IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var customResponse = await _productService.GetProductWithCategory();
            return View(customResponse);
        }

        public async Task<IActionResult> Save()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {

            if (ModelState.IsValid)
            {
                await _productService.AddAsync(_mapper.Map<ProductEntity>(productDto));
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var product=await _productService.GetByIdAsync(id);
            var categories=await _categoryService.GetAllAsync();
            var categoriesDto=_mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories=new SelectList(categoriesDto, "Id", "Name",product.CategoryId);
            return View(_mapper.Map<ProductDto>(product));
        }
        [HttpPost]
        public async Task<IActionResult>Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {

                await _productService.UpdateAsync(_mapper.Map<ProductEntity>(productDto));
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name",productDto.CategoryId);
            return View(productDto);

        }
    }
}
