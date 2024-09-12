using AutoMapper;
using MongoDB.Driver;
using MShop.Catalog.Dtos.ProductImageDtos;
using MShop.Catalog.Entities;
using MShop.Catalog.Settings;

namespace MShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productCollection;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<ProductImage>(databaseSettings.ProducCollectionName);
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            ProductImage? result = _mapper.Map<ProductImage>(createProductImageDto);

            await _productCollection.InsertOneAsync(result);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            List<ProductImage>? products = await _productCollection
                .Find(x => true)
                .ToListAsync();
            List<ResultProductImageDto> result = _mapper.Map<List<ResultProductImageDto>>(products);
            return result;
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            ProductImage? product = await _productCollection
                .Find(x => x.ProductImageId == id)
                .FirstOrDefaultAsync();
            GetByIdProductImageDto result = _mapper.Map<GetByIdProductImageDto>(product);
            return result;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            ProductImage? result = _mapper.Map<ProductImage>(updateProductImageDto);

            await _productCollection
                .FindOneAndReplaceAsync(x =>
                x.ProductImageId == updateProductImageDto.ProductImageId,
                result);
        }
    }
}
