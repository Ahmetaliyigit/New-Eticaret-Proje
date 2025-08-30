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
    public class CountriesController : Controller
    {
        private readonly ICountryService service;

        public CountriesController(ICountryService context)
        {
           service = context;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            return View(await service.GetAllAsync());
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await service.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CountryName")] Country country)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(country);
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await service.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CountryName")] Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await service.UpdateAsync(country);
                    await service.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.Id))
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
            return View(country);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await service.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await service.GetByIdAsync(id);
            if (country != null)
            {
                await service.DeleteAsync(country);
            }

            await service.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
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
