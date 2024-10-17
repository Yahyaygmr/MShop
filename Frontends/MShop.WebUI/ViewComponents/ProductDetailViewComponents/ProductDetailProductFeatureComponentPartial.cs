using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class ProductDetailProductFeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
