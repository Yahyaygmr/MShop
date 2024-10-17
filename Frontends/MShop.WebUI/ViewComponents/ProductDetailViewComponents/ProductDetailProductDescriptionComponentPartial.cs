using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class ProductDetailProductDescriptionComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
