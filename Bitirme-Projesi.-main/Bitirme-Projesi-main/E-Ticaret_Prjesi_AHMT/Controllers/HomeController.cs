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
            private readonly IOrderService orderservice;
            private readonly ICartService cartService;

            public HomeController(IProductService product, IOrderService color,ICartService cartService_)
            {
                cartService = cartService_;
                productservise = product;
                orderservice = color;
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

            [Route("Home/[action]/{id}/{Toplam?}")]
            public async Task<IActionResult> ShoppingCart(int id, string Toplam)
            {
                ViewBag.Id = id;
                ViewBag.Toplamtutar = 0;
                ViewBag.Toplam = Toplam;
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
            public async Task<IActionResult> LoginRegister(string loginpassword, string loginemail)
            {
                return Ok();
            }

            [HttpPost]
            public async Task<IActionResult> PlaceOrder(Order order)
            {
                var user = Program.OnlineUser;
                order.UserNo = user.Id.ToString();


                        order.OrderProducts = user.Cart.CartProducts
                 .Select(cp => new OrderProducts
                 {
                     ProductId = cp.ProductId,
                     Quantity = cp.ProductCount,
                     Price = cp.Product.Price
                 })
                 .ToList(); 


                ModelState.Remove(nameof(order.OrderProducts));
                ModelState.Remove(nameof(order.UserNo));

                if (!ModelState.IsValid)
                {
                    ViewBag.ToplamTutar = user.Cart.CartProducts.Sum(cp => cp.Product.Price * cp.ProductCount);
                    return View("Checkout");
                }

                await orderservice.CreateAsync(order);

                await cartService.DeleteAsync(user.Cart);

                TempData["OrderSuccessMessage"] = "Sipariþiniz baþarýyla oluþturuldu!";
                return RedirectToAction("Index", "Home");
            }
        }
    }
