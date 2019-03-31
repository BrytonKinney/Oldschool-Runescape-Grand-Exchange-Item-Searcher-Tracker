using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RSWebsite.Interfaces;
using RSWebsite.Models;

namespace RSWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRunescapeService _rsService;
        private readonly IMemoryCache _memCache;
        public HomeController(IRunescapeService rsService, IMemoryCache memCache)
        {
            _rsService = rsService;
            _memCache = memCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("item/{id}")]
        public async Task<JsonResult> GetRsItemPrices(string id)
        {
            if(_memCache.TryGetValue(id, out var rso))
                return Json(rso);
            var result = await _rsService.GetGrandExchangeInfo(id);
            _memCache.Set(id, result, TimeSpan.FromMinutes(10));
            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
