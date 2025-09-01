using System.Diagnostics;
using System.Drawing;
using BLL.Abstract;
using BLL.Service;
using E_Ticaret_Prjesi_AHMT.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Prjesi_AHMT.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productservise;


       

        public HomeController(IProductService product)
        {
            productservise = product;
          
        }

        public async Task<IActionResult> Index()
        {             
            return View();
        }

        public async Task<IActionResult> Shop(int Id) 
        {
            ViewBag.Id = Id;
            return View(await productservise.GetAllAsync());
        }

        public async Task<IActionResult> ShopDetails(int Id)
        {
            var detail = await productservise.GetAllAsync(i => i.Id == Id);
            return View(detail.FirstOrDefault());
        }

        public async Task<IActionResult> ShoppingCart(int id)
        {
            ViewBag.Id = id;
            ViewBag.Toplamtutar = 0;
            return View(await productservise.GetAllAsync());
        }

        public async Task<IActionResult> Checkout()
        {
            return View();
        }

        public async Task<IActionResult> ContactUs()
        {
            return View();
        }

        public async Task<IActionResult> LoginRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginRegister(string loginpassword,string loginemail)
        {
            return Ok();
        }
    }
}
