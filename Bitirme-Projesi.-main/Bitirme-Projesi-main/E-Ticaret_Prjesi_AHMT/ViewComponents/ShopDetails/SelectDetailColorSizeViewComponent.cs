using BLL.Abstract;
using BLL.Service;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents
{
    public class SelectDetailColorSizeViewComponent: ViewComponent
    {
        private readonly IProductService servise;
        private readonly IColorService color;

        public SelectDetailColorSizeViewComponent(IProductService product , IColorService colorService)
        {
            servise = product;
            color = colorService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var Product = await servise.GetByIdAsync(Id);
            var Color = await color.GetByIdAsync(Product.ColorId);
            ViewBag.Color = Color.ColorName;
            ViewBag.IsOnline = Program.OnlineUser;
            return View(Product);
        }
    }
}
