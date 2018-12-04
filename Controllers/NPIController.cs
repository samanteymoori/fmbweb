using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FMBPublic.Model;
using FMBPublic.Services;

namespace FMBPublic.Controllers
{
    public class NPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(NPISearchRequest request)
        {
            INPIService INPIService = new NPIService(Connection.GetCs().GetConnection());
            var res = INPIService.SearchNPI(request);
            return View(res);
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
