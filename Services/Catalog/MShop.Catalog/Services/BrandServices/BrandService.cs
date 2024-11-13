using AutoMapper;
using MongoDB.Driver;
using MShop.Catalog.Dtos.BrandDtos;
using MShop.Catalog.Entities;
using MShop.Catalog.Settings;

namespace MShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
            _mapper = mapper;

        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            Brand? result = _mapper.Map<Brand>(createBrandDto);

            await _brandCollection
                .InsertOneAsync(result);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection
                .DeleteOneAsync(x => x.BrandId == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            List<Brand>? categories = await _brandCollection
                .Find(x => true)
                .ToListAsync();

            List<ResultBrandDto>? result = _mapper.Map<List<ResultBrandDto>>(categories);
            return result;
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            Brand? brand = await _brandCollection
                .Find(x => x.BrandId == id)
                .FirstOrDefaultAsync();

            GetByIdBrandDto? result = _mapper.Map<GetByIdBrandDto>(brand);
            return result;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            Brand? result = _mapper.Map<Brand>(updateBrandDto);

            await _brandCollection
                .FindOneAndReplaceAsync(x =>
                x.BrandId == updateBrandDto.BrandId,
                result);
        }
    }
}
