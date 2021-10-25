using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using proba6.Models;
using proba6.Services;

namespace proba6.Areas
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IProductsService _productsService;

        private IWebHostEnvironment _he;

        public ProductController(IProductsService productsService, IWebHostEnvironment he)
        {
            _productsService = productsService;
            _he = he;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _productsService.GetAllAsync();
            return View(data);
        }


        //SEARCH FILTER
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _productsService.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProducts.Where(n => n.ProductName.Contains(searchString) || n.ProductDescription.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allProducts);
        }


        //GET: Product/Create
        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _productsService.GetNewProductCategoryDropdownValues();
            ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");

            return View();
        }


        //POST: Product/Create  
        [HttpPost]
        public async Task<IActionResult> Create(NewProductVm product, IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _productsService.GetNewProductCategoryDropdownValues();

                ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");
      
                return View(product);
            }

            if (image != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                await image.CopyToAsync(new FileStream(name, FileMode.Create));
                product.ProductPicture = "Images/" + image.FileName;
            }

            if (image == null)
            {
                product.ProductPicture = "Images/not-found.jpg";
            }

            await _productsService.AddNewProductAsync(product);
            TempData["save"] = "Added Product is saved";
            return RedirectToAction(nameof(Index));
        }


        //GET: Product/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _productsService.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVm()
            {
                Id = productDetails.Id,
                ProductName = productDetails.ProductName,
                ProductDescription = productDetails.ProductDescription,
                ProductPrice = productDetails.ProductPrice,
                ProductPicture = productDetails.ProductPicture,
                IsAvailable = productDetails.IsAvailable,
                CategoryId = productDetails.CategoryId,
            };

            var productDropdownsData = await _productsService.GetNewProductCategoryDropdownValues();
            ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");
            
            return View(response);
        }


        //POST: Product/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewProductVm product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _productsService.GetNewProductCategoryDropdownValues();
                ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");

                return View(product);
            }

            await _productsService.UpdateMovieAsync(product);
            return RedirectToAction(nameof(Index));
        }


        //GET: Product/Details
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _productsService.GetProductByIdAsync(id);

            if (productDetails == null) return View("NotFound");
            return View(productDetails);
        }


        //POST: Product/Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Product product)
        {
            return RedirectToAction(nameof(Index));
        }


        //GET: Product/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var productDetails = await _productsService.GetProductByIdAsync(id);

            if (productDetails == null) return View("NotFound");
            return View(productDetails);
        }


        //POST: Product/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDetails = await _productsService.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");
        
            await _productsService.DeleteAsync(id);
            TempData["delete"] = "Product has been deleted";
            return RedirectToAction(nameof(Index));
        }
    }
}