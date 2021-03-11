using Microsoft.AspNetCore.Mvc.Rendering;
using SaleShopCore.Application.ViewModels.Common;
using SaleShopCore.Application.ViewModels.Product;
using System.Collections.Generic;

namespace SaleShopCore.Models.ProductViewModels
{
    public class DetailViewModel
    {
        public ProductViewModel Product { get; set; }

        public bool Available { get; set; }

        public List<ProductViewModel> RelatedProducts { get; set; }

        public ProductCategoryViewModel Category { get; set; }

        public List<ProductImageViewModel> ProductImages { set; get; }

        public List<ProductViewModel> UpsellProducts { get; set; }

        public List<TagViewModel> Tags { set; get; }

        public List<SelectListItem> Colors { get; set; }

        public List<SelectListItem> Sizes { get; set; }
    }
}