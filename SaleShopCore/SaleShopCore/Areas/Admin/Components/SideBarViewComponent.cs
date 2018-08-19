using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaleShopCore.Application.Interfaces;
using SaleShopCore.Application.ViewModels.System;
using SaleShopCore.Extensions;
using SaleShopCore.Utilities.Constants;

namespace SaleShopCore.Areas.Admin.Components
{
    public class SideBarViewComponent:ViewComponent
    {
        private IFunctionService _functionService;
        public SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            List<FunctionViewModel> functions;
            if (roles.Split(';').Contains(CommonConstants.AdminRole))
            {
                functions = await _functionService.GetAll();
            }
            else
            {
                functions = new List<FunctionViewModel>();
            }
            return View(functions);
        }
    }
}
