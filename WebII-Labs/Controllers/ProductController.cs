using Microsoft.AspNetCore.Mvc;
using WebII_Labs.Models;

namespace WebII_Labs.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name= "TV",
                    Description="Just for family use",
                    Quantity = 100,
                    UnitPrice=400
                },

                 new Product()
                {
                    Id = 2,
                    Name= "IPhone",
                    Description="Entertainment use",
                    Quantity = 100,
                    UnitPrice=600
                },
                  new Product()
                {
                    Id = 3,
                    Name= "Shoes",
                    Description="Just for wearing",
                    Quantity = 100,
                    UnitPrice=10
                }

            };
            //var productsList = new MyViewModel
            //{
            //    products = products
            //};
            //ViewData["products"] = products;
            return View(products);
        }
    }
}
