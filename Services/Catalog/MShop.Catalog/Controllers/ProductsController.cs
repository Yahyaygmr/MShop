﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.Catalog.Dtos.ProductDtos;
using MShop.Catalog.Services.ProductServices;

namespace MShop.Catalog.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productService.GetAllProductsWithCategoryAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithImages")]
        public async Task<IActionResult> ProductListWithImages()
        {
            var values = await _productService.GetAllProductsWithImagesAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategoryByCategoryId")]
        public async Task<IActionResult> ProductListWithCategoryByCategoryId(string id)
        {
            var values = await _productService.GetAllProductsWithCategoryByCategoryIdAsync(id);
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var value = await _productService.GetByIdProductAsync(id);
            return Ok(value);
        }
        [HttpGet("GetProductWithCategoryById/{id}")]
        public async Task<IActionResult> GetProductWithCategoryById(string id)
        {
            var value = await _productService.GetByIdProductWithCategoryAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            await _productService.CreateProductAsync(dto);
            return Ok("Ürün eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Ürün silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            await _productService.UpdateProductAsync(dto);
            return Ok("Ürün güncellendi.");
        }
    }
}
