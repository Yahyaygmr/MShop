using AutoMapper;
using MongoDB.Driver;
using MShop.Catalog.Dtos.SpecialOfferDtos;
using MShop.Catalog.Entities;
using MShop.Catalog.Settings;

namespace MShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;

        public SpecialOfferService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            SpecialOffer? result = _mapper.Map<SpecialOffer>(createSpecialOfferDto);

            await _specialOfferCollection.InsertOneAsync(result);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            List<SpecialOffer> specialOffers = await _specialOfferCollection
                .Find(x => true)
                .ToListAsync();
            List<ResultSpecialOfferDto> result = _mapper.Map<List<ResultSpecialOfferDto>>(specialOffers);
            return result;

        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            SpecialOffer? specialOffer = await _specialOfferCollection
                .Find(x => x.SpecialOfferId == id)
                .FirstOrDefaultAsync();
            GetByIdSpecialOfferDto result = _mapper.Map<GetByIdSpecialOfferDto>(specialOffer);
            return result;

        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            SpecialOffer result = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);

            await _specialOfferCollection
                .FindOneAndReplaceAsync(x =>
                x.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId, result);
        }
    }
}
