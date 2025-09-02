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
            Product Product = await servise.GetByIdAsync(Id);
            Color Color = await color.GetByIdAsync(Product.ColorId);
            ProductandColor productandColor = new ProductandColor();
            productandColor.Products.Add(Product);
            productandColor.Colors.Add(Color);
            ViewBag.IsOnline = Program.OnlineUser;  
            return View(productandColor);
        }
    }
}
