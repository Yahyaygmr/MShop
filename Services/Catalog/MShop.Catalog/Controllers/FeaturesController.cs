using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.Catalog.Dtos.FeatureDtos;
using MShop.Catalog.Services.FeatureServices;

namespace MShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(string id)
        {
            var value = await _featureService.GetByIdFeatureAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
        {
            await _featureService.CreateFeatureAsync(dto);
            return Ok("Feature eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return Ok("Feature silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {
            await _featureService.UpdateFeatureAsync(dto);
            return Ok("Feature güncellendi.");
        }
    }
}
