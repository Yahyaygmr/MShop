using Microsoft.AspNetCore.Mvc;
using MShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MShop.WebUI.Areas.Admin.ViewComponents.ProductImageViewComponents
{
    public class ProductImageProductDetailComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageProductDetailComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7205/api/Products/GetProductWithCategoryById/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
