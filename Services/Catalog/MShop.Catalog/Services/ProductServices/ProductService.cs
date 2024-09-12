using AutoMapper;
using MongoDB.Driver;
using MShop.Catalog.Dtos.ProductDtos;
using MShop.Catalog.Entities;
using MShop.Catalog.Settings;

namespace MShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProducCollectionName);
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            Product? result = _mapper.Map<Product>(createProductDto);

            await _productCollection.InsertOneAsync(result);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            List<Product>? products = await _productCollection
                .Find(x=>true)
                .ToListAsync();
            List<ResultProductDto> result = _mapper.Map<List<ResultProductDto>>(products);
            return result;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            Product? product = await _productCollection
                .Find(x=>x.ProductId == id)
                .FirstOrDefaultAsync();
            GetByIdProductDto result = _mapper.Map<GetByIdProductDto>(product);
            return result;
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
