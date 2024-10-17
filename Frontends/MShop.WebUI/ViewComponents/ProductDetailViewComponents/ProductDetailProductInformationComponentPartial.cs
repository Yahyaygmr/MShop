using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class ProductDetailProductInformationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
