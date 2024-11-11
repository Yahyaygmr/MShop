using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.Catalog.Dtos.FeatureSliderDtos;
using MShop.Catalog.Services.FeatureSlideServices;

namespace MShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }
        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return Ok(values);
        }
        [HttpGet("FeatureSliderListSatatusTrue")]
        public async Task<IActionResult> FeatureSliderListSatatusTrue()
        {
            var values = await _featureSliderService.GetAllFeatureSliderStatusTrueAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var value = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto dto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(dto);
            return Ok("Öneçıkan Slider eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Öneçıkan Slider silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto dto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(dto);
            return Ok("Öneçıkan Slider güncellendi.");
        }
        [HttpGet("ChangeFeatureSliderStatus/{id}")]
        public async Task<IActionResult> ChangeFeatureSliderStatus(string id)
        {
            await _featureSliderService.FeatureSliderChangeStatus(id);
            return Ok("Öneçıkan Slider durumu güncellendi.");
        }
    }
}
