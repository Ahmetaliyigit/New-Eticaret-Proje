using BLL.Abstract;
using BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.Index
{
    public class SelectTop4ProductViewComponentPartial : ViewComponent
    {
        private readonly IProductService productservise;

        public SelectTop4ProductViewComponentPartial(IProductService product)
        {
            productservise = product;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await productservise.GetAllAsync());
        }
    }
}
