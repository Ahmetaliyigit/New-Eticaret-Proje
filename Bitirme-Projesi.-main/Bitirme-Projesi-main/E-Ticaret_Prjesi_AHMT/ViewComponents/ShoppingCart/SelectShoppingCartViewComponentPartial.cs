using BLL.Abstract;
using BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.ShoppingCart
{
    public class SelectShoppingCartViewComponentPartial : ViewComponent
    {
        private readonly IProductService servise;

        public SelectShoppingCartViewComponentPartial(IProductService productServise)
        {
            servise =  productServise;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Toplamtutar = 0;
            return View(await servise.GetAllAsync());
        }
    }
}
