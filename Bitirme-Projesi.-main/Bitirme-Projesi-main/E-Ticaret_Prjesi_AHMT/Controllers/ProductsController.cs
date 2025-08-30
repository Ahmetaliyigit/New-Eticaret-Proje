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
    public class ProductsController : Controller
    {
        private readonly IProductService service;
        private readonly ICategoryService Cat;
        private readonly IGenderService Gen;
        private readonly IColorService Col;

        public ProductsController(IProductService context, ICategoryService category, IGenderService gender, IColorService color)
        {
            service = context;
            Cat = category;
            Gen = gender;
            Col = color;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var dataContext = service.GetProuctsWithCategoryGenderColorAsync();
            return View(await dataContext);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = (await service.GetProuctsWithCategoryGenderColorAsync(m => m.Id == id)).FirstOrDefault(); // Parantezin sebebi derleyici await i görmeden FirstOrDefaultu görmüyor
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create

        
        public async Task<IActionResult> Create()
        {
            var Pro =  await Col.GetAllAsync();
            var Cato = await Cat.GetAllAsync();
            var Geno = await Gen.GetAllAsync();

            ViewData["CategoryId"] = new SelectList(Cato, "Id", "CategoryName");
            ViewData["ColorId"] = new SelectList(Pro , "Id", "ColorName");
            ViewData["GenderId"] = new SelectList(Geno , "Id", "GenderName");
            return View();
        }   

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("Id,Name,Description,Price,Stock,Url,ColorId,CategoryId,Size,GenderId")] Product product)
        {
            var Category = await Cat.GetOneAsync(c => c.Id == product.CategoryId);
            var Color = await Col.GetOneAsync(c => c.Id == product.ColorId);
            var Gender = await Gen.GetOneAsync(g => g.Id == product.GenderId);

            product.Category = Category;
            product.Color = Color;
            product.Gender = Gender;


            var colors = await Col.GetAllAsync();  
            var categories = await Cat.GetAllAsync();
            var genders = await Gen.GetAllAsync();

            
            if (file != null && file.Length > 0)
            {
                var uploadedFileName = await ImageOperations.UploadImageAsync(file);
                product.Url = uploadedFileName;
            }

            ModelState.Remove("Category");
            ModelState.Remove("Color");
            ModelState.Remove("Gender");
            ModelState.Remove("Url");

            // 2) Model doğrulaması (Url required ise artık product.Url set edilmiş olabilir)
            if (!ModelState.IsValid)
            {           
                ViewData["CategoryId"] = new SelectList(categories, "Id", "CategoryName", product.CategoryId);
                ViewData["ColorId"] = new SelectList(colors, "Id", "ColorName", product.ColorId);
                ViewData["GenderId"] = new SelectList(genders, "Id", "GenderName", product.GenderId);
                return View(product);   
            }

            // 3) Kaydet
            await service.CreateAsync(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Pro = await Col.GetAllAsync();
            var Cato = await Cat.GetAllAsync();
            var Geno = await Gen.GetAllAsync();

            if (id == null)
            {
                return NotFound();
            }

            var product = await service.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(Cato , "Id", "CategoryName", product.CategoryId);
            ViewData["ColorId"] = new SelectList(Pro , "Id", "ColorName", product.ColorId);
            ViewData["GenderId"] = new SelectList(Geno , "Id", "GenderName", product.GenderId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile Photo, int id, [Bind("Id,Name,Description,Price,Stock,Url,ColorId,CategoryId,Size,GenderId")] Product product)
        {
            if (id != product.Id) return NotFound();


            if (Photo != null && Photo.Length > 0)
            {
                product.Url = await ImageOperations.UploadImageAsync(Photo);
            }
    

            ModelState.Remove("Category");
            ModelState.Remove("Color");
            ModelState.Remove("Gender");

            if (ModelState.IsValid)
            {
                await service.UpdateAsync(product);
                await service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // SelectListleri tekrar doldur
            var Pro = await Col.GetAllAsync();
            var Cato = await Cat.GetAllAsync();
            var Geno = await Gen.GetAllAsync();

            ViewData["CategoryId"] = new SelectList(Cato, "Id", "CategoryName", product.CategoryId);
            ViewData["ColorId"] = new SelectList(Pro, "Id", "ColorName", product.ColorId);
            ViewData["GenderId"] = new SelectList(Geno, "Id", "GenderName", product.GenderId);

            return View(product);
        }


        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = (await service.GetProuctsWithCategoryGenderColorAsync(m => m.Id == id)).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await service.GetByIdAsync(id);
            if (product != null)
            {
                await service.DeleteAsync(product);
            }

            await service.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductExists(int id)
        {
            var IsFind = await service.GetByIdAsync(id);
            return IsFind != null;
        }
    }
}
