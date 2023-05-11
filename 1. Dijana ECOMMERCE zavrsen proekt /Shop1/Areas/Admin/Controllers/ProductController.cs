using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Shop1.Areas.Admin.Services;
using Shop1.Data;
using Shop1.Models;
using Shop1.ViewModels;
using Shop1.Services;


namespace Shop1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        private readonly IProductsService _productsService;

        private readonly IWebHostEnvironment _hostEnvironment;


        public ProductController(AppDbContext db,IProductsService productsService, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _productsService = productsService;
            _hostEnvironment = hostEnvironment;
        }


        public async Task<IActionResult> Index( int pg = 1)
        {
            var data = await _productsService.GetAllAsync();

            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int recsCount = data.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var result = data.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(result);
        }

        [Produces("application/json")]
        [HttpGet("search")]
        [Route("api/product/search")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search()
        {
            string term = HttpContext.Request.Query["term"].ToString();

            // vo servis da odi
            var names = _db.Products
                .Where(p => p.ProductName.Contains(term)).Select(p => p.ProductName).ToListAsync();
            return Ok(await names);
        }


        //public async Task<IEnumerable<Product>> GetAllAsync(string searchStrings)
        //{
        //    IQueryable<Product> query = _db.Set<Product>();
        //    query = searchStrings.Aggregate(query, (current, searchString) => current.Include(Char.ToString(searchString)));
        //    return await query.ToListAsync();
        //}



        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _productsService.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allProducts.Where(n => n.ProductName.Contains(searchString) || n.ProductDescription.Contains(searchString)).ToList();
                var filteredResult = allProducts.Where(n => n.ProductName.Contains(searchString)).ToList();
                return View("Index" , filteredResult);
            }

            return View("Index", allProducts);
        }



        //// GET: Product/Create
        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _productsService.GetNewProductCategoryDropdownValues();
            ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");

            return View();
        }


        //// POST: Product/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
 
            if (ModelState.IsValid)
            {
                string uniqueFileName = _productsService.ProcessUploadedFile(model);
                string uniqueFileNameBack = _productsService.ProcessUploadedFileBack(model);

                Product product = new()
                {
                    ProductName = model.ProductName,
                    ProductDescription = model.ProductDescription,
                    ProductPrice = model.ProductPrice,
                    IsAvailable = model.IsAvailable,
                    CategoryId = model.CategoryId,
                    ProductPicture = uniqueFileName,
                    ProductPictureBack = uniqueFileNameBack
                };
                await _productsService.AddAsync(product);
                TempData["save"] = "Added Product is saved";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var productDropdownsData = await _productsService.GetNewProductCategoryDropdownValues();
            ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "CategoryName");

            var productDetails = await _productsService.FindByIdAsync(id);
            var productViewModel = new ProductViewModel()
            {
                Id = productDetails.Id,
                ProductName = productDetails.ProductName,
                ProductDescription = productDetails.ProductDescription,
                ProductPrice = productDetails.ProductPrice,
                IsAvailable = productDetails.IsAvailable,
                CategoryId = productDetails.CategoryId,
                ExistingImage = productDetails.ProductPicture,
                ExistingImageBack = productDetails.ProductPictureBack
            };

            if (productDetails == null)
            {
                var NotFoundViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                return View("Error", NotFoundViewModel);
            }
            return View(productViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productDetails = await _productsService.FindByIdAsync(id);

                productDetails.ProductName = model.ProductName;
                productDetails.ProductDescription = model.ProductDescription;
                productDetails.ProductPrice = model.ProductPrice;
                productDetails.IsAvailable = model.IsAvailable;
                productDetails.CategoryId = model.CategoryId;


                if (model.ProductPictureUpload != null)
                {
                    if (model.ExistingImage != null)
                    {
                        string filePath = Path.Combine(_hostEnvironment.WebRootPath, "Images", model.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }

                    productDetails.ProductPicture = _productsService.ProcessUploadedFile(model);
                }

                if (model.ProductPictureUploadBack != null)
                {
                    if (model.ExistingImageBack != null)
                    {
                        string filePath = Path.Combine(_hostEnvironment.WebRootPath, "Images", model.ExistingImageBack);
                        System.IO.File.Delete(filePath);
                    }

                    productDetails.ProductPictureBack = _productsService.ProcessUploadedFileBack(model);
                }

                await _productsService.UpdateAsync(id, productDetails);
                TempData["edit"] = "Updated product is saved";
                return RedirectToAction(nameof(Index));

            }
            return View();
        }


        //// GET: Product/Details
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                var NotFoundViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                return View("Error", NotFoundViewModel);
            }

            var productDetails = await _productsService.ReturnCategoryByName(id);

            if (productDetails == null)
            {
                var NotFoundViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                return View("Error", NotFoundViewModel);
            }
            return View(productDetails);
        }


        //// POST: Product/Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Product product)
        {
            return RedirectToAction(nameof(Index));
        }


        //// GET: Product/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var productDetails = await _productsService.GetByIdAsync(id);

            if (productDetails == null)
            {
                var NotFoundViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                return View("Error", NotFoundViewModel);
            }
            return View(productDetails);
        }


        //// POST: Product/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDetails = await _productsService.GetByIdAsync(id);
            if (productDetails == null)
            {
                var NotFoundViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                return View("Error", NotFoundViewModel);
            }
            await _productsService.DeleteAsync(id);
            TempData["delete"] = "Product deleted";
            return RedirectToAction(nameof(Index));
        }
    }
}