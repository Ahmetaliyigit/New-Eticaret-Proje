using BLL.Abstract;
using BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.Index
{
    public class SelectNewProductViewComponent : ViewComponent
    {
        private readonly IProductService productServise;

        public SelectNewProductViewComponent(IProductService product)
        {
            productServise = product;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await productServise.GetAllAsync());
        }
    }
}
