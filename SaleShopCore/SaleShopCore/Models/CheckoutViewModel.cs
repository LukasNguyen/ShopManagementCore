using SaleShopCore.Application.ViewModels.Common;
using SaleShopCore.Application.ViewModels.Product;
using SaleShopCore.Data.Enums;
using SaleShopCore.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaleShopCore.Models
{
    public class CheckoutViewModel : BillViewModel
    {
        public List<ShoppingCartViewModel> Carts { get; set; }

        public List<EnumModel> PaymentMethods
        {
            get
            {
                return ((PaymentMethod[])Enum.GetValues(typeof(PaymentMethod)))
                    .Select(c => new EnumModel
                    {
                        Value = (int)c,
                        Name = c.GetDescription()
                    }).ToList();
            }
        }
    }
}