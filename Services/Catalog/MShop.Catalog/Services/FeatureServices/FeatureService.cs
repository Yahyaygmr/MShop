using AutoMapper;
using MongoDB.Driver;
using MShop.Catalog.Dtos.FeatureDtos;
using MShop.Catalog.Entities;
using MShop.Catalog.Settings;

namespace MShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
            _mapper = mapper;

        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            Feature? result = _mapper.Map<Feature>(createFeatureDto);

            await _featureCollection
                .InsertOneAsync(result);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection
                .DeleteOneAsync(x => x.FeatureId == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            List<Feature>? categories = await _featureCollection
                .Find(x => true)
                .ToListAsync();

            List<ResultFeatureDto>? result = _mapper.Map<List<ResultFeatureDto>>(categories);
            return result;
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            Feature? feature = await _featureCollection
                .Find(x => x.FeatureId == id)
                .FirstOrDefaultAsync();

            GetByIdFeatureDto? result = _mapper.Map<GetByIdFeatureDto>(feature);
            return result;
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            Feature? result = _mapper.Map<Feature>(updateFeatureDto);

            await _featureCollection
                .FindOneAndReplaceAsync(x =>
                x.FeatureId == updateFeatureDto.FeatureId,
                result);
        }
    }
}
