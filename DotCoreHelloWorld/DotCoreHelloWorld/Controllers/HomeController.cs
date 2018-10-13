using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotCoreHelloWorld.Models;
using System.Net.Http;
using System.Threading;

using System.Net;




namespace DotCoreHelloWorld
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products = GetProducts().Result.ToList<Product>();
            return View(products);
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> p = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://products-api.cfapps.io/");

            HttpResponseMessage result = await client.GetAsync("api/Product");
            if (result.IsSuccessStatusCode)
            {
                p = await result.Content.ReadAsAsync<List<Product>>();
            }
            return p;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
    }
}
