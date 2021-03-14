using Microsoft.AspNetCore.Mvc;

namespace SaleShopCore.Controllers
{
    public class AjaxContentController : Controller
    {
        public IActionResult HeaderCart()
        {
            return ViewComponent("HeaderCart");
        }
    }
}