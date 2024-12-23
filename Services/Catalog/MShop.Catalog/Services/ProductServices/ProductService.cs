﻿using AutoMapper;
using MongoDB.Driver;
using MShop.Catalog.Dtos.ProductDtos;
using MShop.Catalog.Dtos.ProductImageDtos;
using MShop.Catalog.Entities;
using MShop.Catalog.Settings;

namespace MShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<ProductImage> _productImageCollection;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProducCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProducImageCollectionName);
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            Product? result = _mapper.Map<Product>(createProductDto);

            await _productCollection.InsertOneAsync(result);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            List<Product>? products = await _productCollection
                .Find(x => true)
                .ToListAsync();
            List<ResultProductDto> result = _mapper.Map<List<ResultProductDto>>(products);
            return result;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync()
        {
            List<Product>? products = await _productCollection
                .Find(x => true)
                .ToListAsync();
            List<Category>? categories = await _categoryCollection
                .Find(x => true)
                .ToListAsync();
            List<ResultProductWithCategoryDto> result = new();
            foreach (Product product in products)
            {
                foreach (Category category in categories)
                {
                    if (product.CategoryId == category.CategoryId)
                    {
                        ResultProductWithCategoryDto prd = new()
                        {
                            CategoryId = category.CategoryId,
                            CategoryName = category.CategoryName,
                            Description = product.Description,
                            ImageUrl = product.ImageUrl,
                            Price = product.Price,
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                        };
                        result.Add(prd);
                    }

                }
            }
            return result;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            List<Product>? products = await _productCollection
                .Find(x => x.CategoryId == categoryId)
                .ToListAsync();
            List<Category>? categories = await _categoryCollection
                .Find(x => true)
                .ToListAsync();
            List<ResultProductWithCategoryDto> result = new();
            foreach (Product product in products)
            {
                foreach (Category category in categories)
                {
                    if (product.CategoryId == category.CategoryId)
                    {
                        ResultProductWithCategoryDto prd = new()
                        {
                            CategoryId = category.CategoryId,
                            CategoryName = category.CategoryName,
                            Description = product.Description,
                            ImageUrl = product.ImageUrl,
                            Price = product.Price,
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                        };
                        result.Add(prd);
                    }

                }
            }
            return result;
        }

        public async Task<List<ResultProductWithImageDto>> GetAllProductsWithImagesAsync()
        {

            List<Product>? products = await _productCollection
               .Find(x => true)
               .ToListAsync();
            List<ResultProductWithImageDto> resultList = new();
            foreach (var item in products)
            {
                List<ProductImage>? productImages = await _productImageCollection
              .Find(x => x.ProductId == item.ProductId)
              .ToListAsync();
                List<Category>? categories = await _categoryCollection
               .Find(x => true)
               .ToListAsync();
                var resultImages = _mapper.Map<List<ResultProductImageDto>>(productImages);
                ResultProductWithImageDto result = new()
                {
                    ProductId = item.ProductId,
                    CategoryId = item.CategoryId,
                    Description = item.Description,
                    ImageUrl = item.ImageUrl,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    ProductImages = resultImages
                };
                foreach (Category category in categories)
                {
                    if (item.CategoryId == category.CategoryId)
                    {
                        result.CategoryName = category.CategoryName;
                    }
                }
                resultList.Add(result);
            }
            return resultList;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            Product? product = await _productCollection
                .Find(x => x.ProductId == id)
                .FirstOrDefaultAsync();
            GetByIdProductDto result = _mapper.Map<GetByIdProductDto>(product);
            return result;
        }

        public async Task<ResultProductWithCategoryDto> GetByIdProductWithCategoryAsync(string id)
        {
            Product? product = await _productCollection
                .Find(x => x.ProductId == id)
                .FirstOrDefaultAsync();
            Category? category = await _categoryCollection
               .Find(x => x.CategoryId == product.CategoryId)
               .FirstOrDefaultAsync();
            ResultProductWithCategoryDto prd = new()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
            };
            return prd;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            Product? result = _mapper.Map<Product>(updateProductDto);

            await _productCollection
                .FindOneAndReplaceAsync(x =>
                x.ProductId == updateProductDto.ProductId,
                result);
        }
    }
}
