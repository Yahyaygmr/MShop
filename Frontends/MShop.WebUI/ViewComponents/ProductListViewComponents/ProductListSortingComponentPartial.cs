using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class ProductListSortingComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
