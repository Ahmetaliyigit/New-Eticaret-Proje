using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Concrate.EfCore.Context;
using Entity;
using BLL.Abstract;

namespace E_Ticaret_Prjesi_AHMT.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService service;

        public OrdersController(DataContext context , IOrderService orderService)
        {
            service = orderService;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await service.GetAllAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await service.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }


      

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await service.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await service.GetByIdAsync(id);
            if (order != null)
            {
                await service.DeleteAsync(order);
            }

            await service.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            var IsValid = service.GetByIdAsync(id);

            if (id != null)
            {  
                return true;

            }

            else
            {
                return false;
            }
              
        }
    }
}
