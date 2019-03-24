using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSWebsite.Interfaces;
using RSWebsite.Models;

namespace RSWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGrandExchangeService _geService;
        
        public HomeController(IGrandExchangeService geSvc)
        {
            _geService = geSvc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("item/{id}")]
        public async Task<JsonResult> GetRsItemPrices(string id)
        {
            var itemPrices = await _geService.GetItem(id);
            var itemChart = await _geService.GetItemChart(id);
            string mergedResults = $"[{itemPrices}, {itemChart}]";
            return Json(mergedResults);
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
