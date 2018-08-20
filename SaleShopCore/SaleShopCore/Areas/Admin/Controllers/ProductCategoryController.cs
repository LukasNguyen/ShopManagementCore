using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleShopCore.Application.Interfaces;

namespace SaleShopCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Get Data API
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productCategoryService.GetAll();
            return new OkObjectResult(model);
        }
        #endregion
    }
}