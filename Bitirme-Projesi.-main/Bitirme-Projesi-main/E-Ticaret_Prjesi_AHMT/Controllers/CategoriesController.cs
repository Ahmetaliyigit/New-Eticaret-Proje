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
using WebUI.Services;

namespace E_Ticaret_Prjesi_AHMT.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService service;

        public CategoriesController(ICategoryService context)
        {
            service = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await service.GetAllAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await service.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file,[Bind("Id,CategoryName,Url")] Category category)
        {

            if (file != null && file.Length > 0)
            {
                var uploadedFileName = await ImageOperations.UploadImageAsync(file);
                category.Url = uploadedFileName;
            }

            ModelState.Remove("Url");

            if (ModelState.IsValid)
            {
               
                await service.CreateAsync(category);
                await service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await service.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(IFormFile Foto,int id, [Bind("Id,CategoryName,Url")] Category category)
            {

            if (id != category.Id) return NotFound();

            // Mevcut category'yi DB'den çekiyoruz (tracked entity)
            var existingCategory = await service.GetByIdAsync(id);
            if (existingCategory == null) return NotFound();

            // Fotoğraf varsa yükle, yoksa eski URL'yi koru
            if (Foto != null && Foto.Length > 0)
            {
                existingCategory.Url = await ImageOperations.UploadImageAsync(Foto);
            }
            else
            {
                existingCategory.Url = existingCategory.Url;

                // Foto alanındaki validation hatasını temizle
                ModelState.Remove("Foto");
            }

            // Alanları güncelle (tracked entity)
            existingCategory.CategoryName = category.CategoryName;

            // Url alanı için ModelState hatasını temizle
            ModelState.Remove("Url");

            if (!ModelState.IsValid)
            {
                // Hataları loglamak / görmek için
                var errors = ModelState
                    .Where(kvp => kvp.Value.Errors.Any())
                    .Select(kvp => new
                    {
                        Key = kvp.Key,
                        Errors = kvp.Value.Errors
                            .Select(e => string.IsNullOrEmpty(e.ErrorMessage) ? e.Exception?.Message : e.ErrorMessage)
                            .ToArray()
                    }).ToList();

                // Konsola yazdır (istersen View'a da gönderebilirsin)
                foreach (var err in errors)
                {
                    foreach (var msg in err.Errors)
                    {
                        Console.WriteLine($"Field: {err.Key}, Error: {msg}");
                    }
                }

                return View(existingCategory);
            }

            try
            {
                await service.UpdateAsync(existingCategory);
                await service.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(existingCategory.Id))
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

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await service.GetByIdAsync(id);
            if (category == null) 
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await service.GetByIdAsync(id);
            if (category != null)
            {
                await service.DeleteAsync(category);
            }

            await service.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
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
