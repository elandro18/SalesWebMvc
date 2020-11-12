using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordsService _salesRecordsService;

        public SalesRecordsController(SalesRecordsService salesRecordsService)
        {
            _salesRecordsService = salesRecordsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? mindate, DateTime? maxdate)
        {
            if (!mindate.HasValue)
            {
                mindate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxdate.HasValue)
            {
                maxdate = DateTime.Now;
            }
            ViewData["minDate"] = mindate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxdate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordsService.FindByDateAsync(mindate, maxdate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? mindate, DateTime? maxdate)
        {
            if (!mindate.HasValue)
            {
                mindate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxdate.HasValue)
            {
                maxdate = DateTime.Now;
            }
            ViewData["minDate"] = mindate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxdate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordsService.FindByDateGroupingAsync(mindate, maxdate);
            return View(result);
        }
    }
}
