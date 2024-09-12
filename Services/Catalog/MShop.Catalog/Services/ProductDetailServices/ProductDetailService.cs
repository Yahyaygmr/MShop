using AutoMapper;
using MongoDB.Driver;
using MShop.Catalog.Dtos.ProductDetailDtos;
using MShop.Catalog.Entities;
using MShop.Catalog.Settings;

namespace MShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;

        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProducDetailCollectionName);
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            ProductDetail? result = _mapper.Map<ProductDetail>(createProductDetailDto);

            await _productDetailCollection.InsertOneAsync(result);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x=>x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            List<ProductDetail>? products = await _productDetailCollection
                .Find(x=>true)
                .ToListAsync();
            List<ResultProductDetailDto> result = _mapper.Map<List<ResultProductDetailDto>>(products);
            return result;
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            ProductDetail? product = await _productDetailCollection
                .Find(x=>x.ProductDetailId == id)
                .FirstOrDefaultAsync();
            GetByIdProductDetailDto result = _mapper.Map<GetByIdProductDetailDto>(product);
            return result;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            ProductDetail? result = _mapper.Map<ProductDetail>(updateProductDetailDto);

            await _productDetailCollection
                .FindOneAndReplaceAsync(x =>
                x.ProductDetailId == updateProductDetailDto.ProductDetailId,
                result);
        }
    }
}
