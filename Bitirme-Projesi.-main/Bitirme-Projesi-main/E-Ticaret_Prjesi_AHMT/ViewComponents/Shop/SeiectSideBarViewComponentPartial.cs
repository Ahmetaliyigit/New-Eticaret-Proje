using BLL.Abstract;
using BLL.Service;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.Shop
{
    public class SeiectSideBarViewComponentPartial : ViewComponent
    {
        private readonly IProductService productServise;
        private readonly IColorService color;
        private readonly IGenderService gender;

        public SeiectSideBarViewComponentPartial(IProductService product, IColorService color1,IGenderService gender1)
        {
            productServise = product;
            color = color1;
            gender = gender1;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {        
            var Product = await productServise.GetProuctsWithCategoryGenderColorAsync();
            var Colors = await color.GetAllAsync();
            var Genders = await gender.GetAllAsync();

            ProductandColor productand = new ProductandColor()
            {
                Products = Product,
                Colors = Colors,
                Genders = Genders
            };

            return View(productand);


        }
    }
}
