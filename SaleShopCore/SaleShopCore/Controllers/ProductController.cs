using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaleShopCore.Application.Interfaces;
using SaleShopCore.Models.ProductViewModels;

namespace SaleShopCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IConfiguration _configuration;
        public ProductController(IProductService productService, IConfiguration configuration,
            IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _configuration = configuration;
        }

        [Route("products.html")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("{alias}-c.{id}.html", Name = "Catalog")]
        public IActionResult Catalog(int id, int? pageSize, string sortBy, int page = 1)
        {
            ViewData["BodyClass"] = "shop_grid_full_width_page";

            var catalog = new CatalogViewModel();

            if (pageSize == null)
                pageSize = _configuration.GetValue<int>("PageSize");

            catalog.PageSize = pageSize;
            catalog.SortType = sortBy;
            catalog.Data = _productService.GetAllPaging(id, string.Empty, page, pageSize.Value);
            catalog.Category = _productCategoryService.GetById(id);

            return View(catalog);
        }

        [Route("{alias}-p.{id}.html", Name = "ProductDetail")]
        public IActionResult Details(int id)
        {
            return View();
        }

    }
}