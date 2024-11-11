using Microsoft.AspNetCore.Mvc;
using MShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultFeatureSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultFeatureSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/FeatureSliders/FeatureSliderListSatatusTrue");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
