using BLL.Abstract;
using BLL.Service;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.ViewComponents.Shop
{
    public class SelectProductViewComponentPartial : ViewComponent
    {
        private readonly IProductService productservise;

        public SelectProductViewComponentPartial(IProductService servise)
        {
            productservise = servise;
        }

        public async Task<IViewComponentResult> InvokeAsync(int Id)
            {


            
            if (Id == 999)
            {
                return View(await productservise.GetAllAsync(i => i.Price > 0 && i.Price < 100));
            } //  0 - 100
            else if (Id == 998)
            {
                return View(await productservise.GetAllAsync(i => i.Price > 100 && i.Price < 200));
            }// 100 - 200
            else if (Id == 997)
            {
                return View(await productservise.GetAllAsync(i => i.Price > 200 && i.Price < 300));
            }// 200 - 300
            else if (Id == 996)
            {
                return View(await productservise.GetAllAsync(i => i.Price > 300 && i.Price < 400));
            } // 300 - 400
            else if (Id == 995)
            {
                return View(await productservise.GetAllAsync(i => i.Price > 400 && i.Price < 500));
            }// 400 - 500
           else if (Id == 2323)
            {
                return View(await productservise.GetAllAsync(i => i.Size == "XS"));
            } // XS olanları çağır
            else if (Id == 3434)
            {
                return View(await productservise.GetAllAsync(i => i.Size == "S"));
            }// S olanları çağır  
            else if (Id == 4545)
            {
                return View(await productservise.GetAllAsync(i => i.Size == "M"));
            } // M olanları çağır
            else if (Id == 5656)
            {
                return View(await productservise.GetAllAsync(i => i.Size == "L"));
            }// L olanları çağır
            else if (Id == 6767)
            {
                return View(await productservise.GetAllAsync(i => i.Size == "XL"));
            }// XL olanları çağır
            else if (Id == 0)
            {
                return View(await productservise.GetAllAsync());
            } //  Alayını çağır
            else if (Id > 1000000)
            {
                Id = Id - 1000000;
                return View(await productservise.GetAllAsync(i => i.ColorId == Id));
            }// Renklere göre çağır
            else if (Id > 10000 )
            {
                Id = Id - 10000;
                return View(await productservise.GetAllAsync(i => i.GenderId == Id));
            }  // Cinsiyete göre çağır
            else
            {
                return View(await productservise.GetAllAsync(i => i.CategoryId == Id));
            } // Kategoriye göre çağır
        }
    }
}
