using AutoMapper;
using MongoDB.Driver;
using MShop.Catalog.Dtos.FeatureSliderDtos;
using MShop.Catalog.Entities;
using MShop.Catalog.Settings;

namespace MShop.Catalog.Services.FeatureSlideServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
        }
        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            FeatureSlider? featureSlider = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureSliderCollection.InsertOneAsync(featureSlider);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            var result = await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId == id);
        }

        public async Task FeatureSliderChangeStatus(string id)
        {
            FeatureSlider? featureSlider = await _featureSliderCollection
                .Find(x => x.FeatureSliderId == id)
                .FirstOrDefaultAsync();
            if (featureSlider.Status)
                featureSlider.Status = false;
            else
                featureSlider.Status = true;

            await _featureSliderCollection
            .FindOneAndReplaceAsync(x =>
            x.FeatureSliderId == featureSlider.FeatureSliderId, featureSlider);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            List<FeatureSlider> featureSliders = await _featureSliderCollection
                .Find(x => true)
                .ToListAsync();
            List<ResultFeatureSliderDto> result = _mapper.Map<List<ResultFeatureSliderDto>>(featureSliders);
            return result;
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            FeatureSlider? featureSlider = await _featureSliderCollection
                .Find(x => x.FeatureSliderId == id)
                .FirstOrDefaultAsync();
            GetByIdFeatureSliderDto result = _mapper.Map<GetByIdFeatureSliderDto>(featureSlider);
            return result;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            FeatureSlider? result = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);

            await _featureSliderCollection
            .FindOneAndReplaceAsync(x =>
            x.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId, result);
        }
    }
}
