using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using proba6.Data;
using proba6.Models;
using proba6.Services;
using proba6.Utility;

namespace proba6.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private AppDbContext _db;

        private readonly IProductsService _productsService;

        public HomeController(AppDbContext db, IProductsService productsService)
        {
            _db = db;
            _productsService = productsService;
        }

        public IActionResult Landing()
        {
            return View();
        }

        public IActionResult Index(int? page)
        {
            return View(_db.Products.Include(c => c.Categories).ToList());
            //ToPagedList(page ?? 1, 9));
            //Include(c => c.SpecialTag).ToList());

        }


        [Produces("application/json")]
        [HttpGet("search")]
        [Route("api/product/search")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();

                //var names = db.Vendors.Where(p => p.Name.Contains(term)).Select(p => p.Name).ToListAsync();
                var names = _db.Products
                    .Where(p => p.ProductName.Contains(term)).Select(p => p.ProductName).ToListAsync();
                return Ok(await names);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


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


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //GET product detail action method

        public ActionResult Detail(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.Include(c => c.Categories).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        //POST product detail action method
        [HttpPost]
        [ActionName("Detail")]
        public ActionResult ProductDetail(int? id)
        {
            List<Product> products = new List<Product>();
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.Include(c => c.Categories).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            products = HttpContext.Session.Get<List<Product>>("products");
            if (products == null)
            {
                products = new List<Product>();
            }

            products.Add(product);
            HttpContext.Session.Set("products", products);
            return RedirectToAction(nameof(Index));
        }

        //GET Remove action method
        [ActionName("Remove")]
        public IActionResult RemoveToCart(int? id)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }




        //POST product remove action method
        [HttpPost]
        public IActionResult Remove(int? id)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }


        //GET product Cart action method

        public IActionResult Cart()
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products == null)
            {
                products = new List<Product>();
            }
            return View(products);
        }
    }
}