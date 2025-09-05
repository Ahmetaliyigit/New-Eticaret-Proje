using BLL.Abstract;
using BLL.Service;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.Checkout
{
        public class SelectCheckoutViewComponentPartial : ViewComponent
        {
            private readonly ICountryService countryService;

            public SelectCheckoutViewComponentPartial(ICountryService countryService)
            {
                this.countryService = countryService;
            }

            public async Task<IViewComponentResult> InvokeAsync()
            {
                List<Country> Countrys = await countryService.GetAllAsync();
                ViewBag.Country = Countrys;
                ViewBag.ToplamTutar = 0;
                List<CartProduct> CartProductList = Program.OnlineUser.Cart.CartProducts;
                return View(CartProductList);
            }
        }
    }
