using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class ProductDetailUMayAlsoLikeComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
