using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using proba6.Models;
using proba6.Services;

namespace proba6.Areas
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoriesService _categoriesService;

        public CategoryController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _categoriesService.GetAllAsync();
            return View(data);
        }


        //GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }


        //POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryName")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            await _categoriesService.AddAsync(category);
            TempData["save"] = "Added Category is saved";
            return RedirectToAction(nameof(Index));
        }


        //GET: Category/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDetails = await _categoriesService.GetByIdAsync(id);

            if (categoryDetails == null) return View("NotFound");
            return View(categoryDetails);
        }


        //POST: Category/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, CategoryName")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            await _categoriesService.UpdateAsync(id, category);
            TempData["edit"] = "Category is updated";
            return RedirectToAction(nameof(Index));
        }


        //GET: Products/Details
        public async Task<IActionResult> Details(int id)
        {
            var categoryDetails = await _categoriesService.GetByIdAsync(id);

            if (categoryDetails == null) return View("NotFound");
            return View(categoryDetails);
        }


        //POST: Products/Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Category category)
        {
            return RedirectToAction(nameof(Index));
        }


        //GET: Products/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDetails = await _categoriesService.GetByIdAsync(id);

            if (categoryDetails == null) return View("NotFound");
            return View(categoryDetails);
        }


        //POST: Products/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryDetails = await _categoriesService.GetByIdAsync(id);
            if (categoryDetails == null) return View("NotFound");
        
            await _categoriesService.DeleteAsync(id);
            TempData["delete"] = "Category has been deleted";
            return RedirectToAction(nameof(Index));
        }
    }
}
