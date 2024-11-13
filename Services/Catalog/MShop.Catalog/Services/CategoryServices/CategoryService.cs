using AutoMapper;
using MongoDB.Driver;
using MShop.Catalog.Dtos.CategoryDtos;
using MShop.Catalog.Entities;
using MShop.Catalog.Settings;
using System.Collections.Generic;

namespace MShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProducCollectionName);
            _mapper = mapper;

        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            Category? result = _mapper.Map<Category>(createCategoryDto);

            await _categoryCollection
                .InsertOneAsync(result);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection
                .DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            List<Category>? categories = await _categoryCollection
                .Find(x => true)
                .ToListAsync();

            List<ResultCategoryDto>? result = _mapper.Map<List<ResultCategoryDto>>(categories);
            return result;
        }

        public async Task<List<ResultCategoriWithProductCount>> GetAllCategoryWithProductCountAsync()
        {
            List<Category>? categories = await _categoryCollection
                 .Find(x => true)
                 .ToListAsync();

            List<ResultCategoriWithProductCount> results = new();

            int productCount = 0;

            foreach (var category in categories)
            {
                List<Product>? products = await _productCollection
                .Find(x => x.CategoryId == category.CategoryId)
                .ToListAsync();
                productCount = products?.Count ?? 0;

                ResultCategoriWithProductCount result = new()
                {
                    CategoryId = category.CategoryId,
                    ProductCount = productCount,
                    CategoryName = category.CategoryName,
                    ImageUrl = category.ImageUrl,
                };
                results.Add(result);
            }
            return results;
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            Category? category = await _categoryCollection
                .Find(x => x.CategoryId == id)
                .FirstOrDefaultAsync();

            GetByIdCategoryDto? result = _mapper.Map<GetByIdCategoryDto>(category);
            return result;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            Category? result = _mapper.Map<Category>(updateCategoryDto);

            await _categoryCollection
                .FindOneAndReplaceAsync(x =>
                x.CategoryId == updateCategoryDto.CategoryId,
                result);
        }
    }
}
