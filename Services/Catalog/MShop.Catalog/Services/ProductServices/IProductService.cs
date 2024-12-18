﻿using MShop.Catalog.Dtos.ProductDtos;

namespace MShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync();
        Task<List<ResultProductWithImageDto>> GetAllProductsWithImagesAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryByCategoryIdAsync(string categoryId);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<ResultProductWithCategoryDto> GetByIdProductWithCategoryAsync(string id);
    }
}
