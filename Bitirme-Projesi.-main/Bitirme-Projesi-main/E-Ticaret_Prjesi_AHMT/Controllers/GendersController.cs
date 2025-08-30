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
    public class GendersController : Controller
    {
        private readonly IGenderService service ;

        public GendersController(IGenderService context)
        {
            service = context;
        }

        // GET: Genders
        public async Task<IActionResult> Index()
        {
            return View(await service.GetAllAsync());
        }

        // GET: Genders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gender = await service.GetByIdAsync(id);
            if (gender == null)
            {
                return NotFound();
            }

            return View(gender);
        }

        // GET: Genders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GenderName")] Gender gender)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(gender);
                await service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(gender);
        }

        // GET: Genders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gender = await service.GetByIdAsync(id);
            if (gender == null)
            {
                return NotFound();
            }
            return View(gender);
        }

        // POST: Genders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GenderName")] Gender gender)
        {
            if (id != gender.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await service.UpdateAsync(gender);
                    await service.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenderExists(gender.Id))
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
            return View(gender);
        }

        // GET: Genders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gender = await service.GetByIdAsync(id);
            if (gender == null)
            {
                return NotFound();
            }

            return View(gender);
        }

        // POST: Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gender = await service.GetByIdAsync(id);
            if (gender != null)
            {
                await service.DeleteAsync(gender);
            }

            await service.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool GenderExists(int id)
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
