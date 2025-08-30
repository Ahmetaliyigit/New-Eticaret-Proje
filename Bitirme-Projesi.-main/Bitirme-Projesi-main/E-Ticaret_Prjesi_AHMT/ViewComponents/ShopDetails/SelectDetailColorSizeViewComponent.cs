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
            
            var Product = await servise.GetAllAsync(i => i.Id == Id);
            var Colors = await color.GetAllAsync(i => i.Id == Product.FirstOrDefault().ColorId);
            ViewBag.Color = Colors.FirstOrDefault().ColorName;
            return View(Product.FirstOrDefault());
        }
    }
}
