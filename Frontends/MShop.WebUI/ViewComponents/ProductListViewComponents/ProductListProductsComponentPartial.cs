using Microsoft.AspNetCore.Mvc;
using MShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class ProductListProductsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListProductsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? id)
        {
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage;
            if (string.IsNullOrWhiteSpace(id))
            {
                responseMessage = await client.GetAsync("https://localhost:7205/api/Products/ProductListWithCategory");
            }
            else
            {
                responseMessage = await client.GetAsync($"https://localhost:7205/api/Products/ProductListWithCategoryByCategoryId?id={id}");
            }
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
