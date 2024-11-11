using MShop.Catalog.Dtos.FeatureSliderDtos;

namespace MShop.Catalog.Services.FeatureSlideServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderStatusTrueAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderChangeStatus(string id);
    }
}
