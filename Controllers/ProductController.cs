using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shopapp.webui.Data;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class ProductController : Controller
    {
        //localhost:5000/product/index
        public IActionResult Index()
        {
            // ViewBag
            // Models
            //ViewData

            var product = new Product { Name = "Iphone X", Price = 6000, Description = "Güzel telefon" };
            // ViewData["Product"] = product;
            // ViewData["Category"] = "Telefonlar";

            ViewBag.Category = "Telefonlar";
            // ViewBag.Product = product;

            return View(product);
        }

        //localhost:5000/product/index
        public IActionResult List(int? id, string q)
        {
            // Query String
            // Console.WriteLine(q);
            // System.Console.WriteLine(HttpContext.Request.Query["q"].ToString());


            var products = ProductRepository.Products;
            if (id != null)
            {
                products = products.Where(p => p.CategoryId == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                products = products.Where(i => i.Name.ToLower().Contains(q.ToLower()) || i.Description.ToLower().Contains(q.ToLower())).ToList();
            }

            var productViewModel = new ProductViewModel() { Products = products };

            return View(productViewModel);
        }

        //localhost:5000/product/Details
        public IActionResult Details(int id)
        {
            return View(ProductRepository.GetProductById(id));
        }


        //httpget
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            ProductRepository.AddProduct(p);
            return RedirectToAction("list");
        }
    }
}