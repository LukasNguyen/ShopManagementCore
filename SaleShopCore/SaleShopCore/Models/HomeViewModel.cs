using SaleShopCore.Application.ViewModels.Blog;
using SaleShopCore.Application.ViewModels.Common;
using SaleShopCore.Application.ViewModels.Product;
using System.Collections.Generic;

namespace SaleShopCore.Models
{
    public class HomeViewModel
    {
        public List<BlogViewModel> LastestBlogs { get; set; }

        public List<SlideViewModel> HomeSlides { get; set; }

        public List<ProductViewModel> HotProducts { get; set; }

        public List<ProductViewModel> TopSellProducts { get; set; }

        public List<ProductCategoryViewModel> HomeCategories { set; get; }

        public string Title { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
    }
}