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
    public class ColorsController : Controller
    {
        private readonly IColorService service;

        public ColorsController(IColorService context)
        {
            service = context;
        }

        // GET: Colors
        public async Task<IActionResult> Index()
        {
            return View(await service.GetAllAsync());
        }

        // GET: Colors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await service.GetByIdAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // GET: Colors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ColorName")] Color color)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(color);
                await service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

        // GET: Colors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await service.GetByIdAsync(id);
            if (color == null)
            {
                return NotFound();
            }
            return View(color);
        }

        // POST: Colors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ColorName")] Color color)
        {
            if (id != color.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await service.UpdateAsync(color);
                    await service.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColorExists(color.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

        // GET: Colors/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await service.GetByIdAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // POST: Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var color = await service.GetByIdAsync(id);
            if (color != null)
            {
                await service.DeleteAsync(color);
            }

            await service.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ColorExists(int id)
        {
            var IsFind = service.GetByIdAsync(id);

            if (IsFind == null)
            {
                return false;
            }
            return true;
        }
    }
}
