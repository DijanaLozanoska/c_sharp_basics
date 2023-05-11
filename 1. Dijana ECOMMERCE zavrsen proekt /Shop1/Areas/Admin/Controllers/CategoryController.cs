using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop1.Areas.Admin.Services;
using Shop1.Data;
using Shop1.Models;

namespace Shop1.Areas.Admin.Controllers
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


        //// GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }


        //// POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryName")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (ModelState.IsValid)
            {
                var categoryDetails = await _categoriesService.GetByCategoryName(category);
                if (categoryDetails != null)
                {
                    ViewBag.message = "This category already exists";
                    return View(category);
                }  
                await _categoriesService.AddAsync(category);
            } 
            TempData["save"] = "Added Category is saved";
            return RedirectToAction(nameof(Index));
        }


        //// GET: Category/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDetails = await _categoriesService.GetByIdAsync(id);

            if (categoryDetails == null)
            {
                var NotFoundViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                return View("Error", NotFoundViewModel);
            }

            return View(categoryDetails);
        }


        //// POST: Category/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, CategoryName")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            await _categoriesService.UpdateAsync(id, category);
            TempData["edit"] = "Updated category is saved";
            return RedirectToAction(nameof(Index));
        }


        //GET: Category/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDetails = await _categoriesService.GetByIdAsync(id);

            if (categoryDetails == null)
            {
                var NotFoundViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                return View("Error", NotFoundViewModel);
            }

            return View(categoryDetails);
        }


        //POST: Category/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryDetails = await _categoriesService.GetByIdAsync(id);
            if (categoryDetails == null)
            {
                var NotFoundViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                return View("Error", NotFoundViewModel);
            }

            await _categoriesService.DeleteAsync(id);
            TempData["delete"] = "Category deleted";
            return RedirectToAction(nameof(Index));
        }
    }
}