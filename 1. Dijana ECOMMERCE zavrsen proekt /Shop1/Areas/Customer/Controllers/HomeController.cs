using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop1.Areas.Admin.Services;
using Shop1.Data;
using Shop1.Models;
using Shop1.Services;
using Shop1.Utility;


namespace Shop1.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly IHomeService _homeService;
        private readonly ICategoriesService _categoriesService;


        public HomeController(IHomeService homeService, ICategoriesService categoriesService, IProductsService productsService)
        {
            _homeService = homeService;
            _productsService = productsService;
            _categoriesService = categoriesService;
        }


        public IActionResult Landing()
        {
            return View();
        }

        public IActionResult Index(int? id)
        {
            var result = _homeService.Merge(id);
            return View(result);
        }


        public IActionResult Cart()
        {
            var result = _homeService.Cart();
            return View(result);
        }


        //// GET: Cart/Details
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return Error();
            }

            var productDetails = await _productsService.GetByIdAsync(id);
            //var productDetails = await _productsService.ReturnCategoryByName(id);

            if (productDetails == null)
            {
                return Error();
            }
            return View(productDetails);
        }


        //// POST: Cart/Details
        [HttpPost]
        [ActionName("Details")]
        public async Task<IActionResult> ProductDetail(int id)
        {
            if (id == null)
            {
                return Error();
            }

            var product = await _productsService.GetByIdAsync(id);

            if (product == null)
            {
                return Error();
            }

            var products = _homeService.Cart();
            var data = await _homeService.Add(id);

            return RedirectToAction(nameof(Index));
        }


        //// GET: Cart/Delete
        [ActionName("Delete")]
        public IActionResult DeleteFromCart(int? id)
        {
            if (ModelState.IsValid)
            {
                var result = _homeService.Delete(id);
            }
            return RedirectToAction(nameof(Cart));
        }


        //// POST: Cart/Delete 
        [HttpPost]
        public IActionResult Delete(int? id)    
        {
            if (ModelState.IsValid)
            {
                var result = _homeService.Delete(id);
                return View(result);
            }
             return RedirectToAction(nameof(Cart));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}

    


