using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop1.Data;
using Shop1.Models;
using Shop1.Utility;

namespace Shop1.Areas
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _db;

        public OrderController(AppDbContext db)
        {
            _db = db;
        }

        //GET Checkout actioin method
        public IActionResult Checkout()
        {
            return View();
        }

        //POST Checkout action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(Order anOrder)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products != null)
            {
                foreach (var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.ProductId = product.Id;
                    anOrder.OrderDetails.Add(orderDetails);
                }
            }

            anOrder.OrderNo = GetOrderNo();
            _db.Orders.Add(anOrder);
            await _db.SaveChangesAsync();
            HttpContext.Session.Set("products", new List<Product>());
            return View();
        }


        public ActionResult Count()
        {
            int count = 0;
            List<Product> productsc = HttpContext.Session.Get<List<Product>>("products");
            if (productsc == null)
            {
                productsc = new List<Product>();
            }
            count = productsc.Count();
            return View(count);
        }


        public string GetOrderNo()
        {
            int rowCount = _db.Orders.ToList().Count() + 1;
            return rowCount.ToString("000");
        }

        //GET Checkout actioin method
        public IActionResult OrderHistoryList()
        {
            return View();
        }


        //GET Index Action Method
        public IActionResult Index()
        {
            return View(_db.Orders.ToList());
        }


        //GET Create Action Method
        public ActionResult CreateOrder()
        {
            return View();
        }


        //POST Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            //List<Product> products = HttpContext.Session.Get<List<Product>>("products");

            //if (products != null)
            //{
            //    foreach (var product in products)
            //    {
            //        OrderDetails orderDetails = new OrderDetails();
            //        orderDetails.ProductId = product.Id;
            //        order.OrderDetails.Add(orderDetails);
            //    }
            //}

            //order.OrderNo = GetOrderNo1();
            //_db.Orders.Add(order);
            //await _db.SaveChangesAsync();
            ////HttpContext.Session.Set("products", new List<Product>());
            ////return View();

            if (ModelState.IsValid)
            {
                _db.Orders.Add(order);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }
    }
}