using Microsoft.AspNetCore.Mvc;
using MShop.DtoLayer.CatalogDtos.ProductDtos;
using MShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MShop.WebUI.Areas.Admin.ViewComponents.ProductImageViewComponents
{
    public class ProductImageProductImageListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageProductImageListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7205/api/ProductImages/ProductImageListByProductId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultProductImageDto>());
        }
    }
}
