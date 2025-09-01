using BLL.Abstract;
using BLL.Service;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.ShoppingCart
{
    public class SelectShoppingCartViewComponentPartial : ViewComponent
    {
        private readonly IProductService servise;
        private readonly ICartService cartService; 
             
        public SelectShoppingCartViewComponentPartial(IProductService productServise, ICartService CartService)
        {
            servise =  productServise;
            cartService = CartService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var User = Program.OnlineUser;
            var Product = await servise.GetByIdAsync(Id);
            var Cart = await cartService.GetCartWithProductAsync(i => i.UserId == User.Id);

            if (Id == 0)
            {
                return View(Cart.Products);
            }
            if (Cart == null)
            {
                Cart a = new Cart();
                a.UserId = User.Id;
                a.Products.Add(Product); 
                await cartService.CreateAsync(a);
                return View(a.Products);
            }
            else
            {
                Cart.Products.Add(Product);
                await cartService.SaveChanges();
                return View(Cart.Products);
            }

           
        }
    }
}
