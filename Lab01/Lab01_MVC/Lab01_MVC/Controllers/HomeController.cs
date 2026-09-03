using Lab01_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab01_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product Name 1",
                    Image = "/images/product1.jpg",
                    Price = 500000,
                    CreatedAt = new DateTime(2020, 12, 25)
                },

                new Product
                {
                    Id = 2,
                    Name = "Product Name 2",
                    Image = "/images/product2.jpg",
                    Price = 700000,
                    CreatedAt = new DateTime(2020, 12, 25)
                },

                new Product
                {
                    Id = 3,
                    Name = "Product Name 3",
                    Image = "/images/product3.jpg",
                    Price = 550000,
                    CreatedAt = new DateTime(2020, 12, 25)
                },

                new Product
                {
                    Id = 4,
                    Name = "Product Name 4",
                    Image = "/images/product4.jpg",
                    Price = 550000,
                    CreatedAt = new DateTime(2020, 12, 25)
                }
            };

            return View(products);
        }
    }
}
