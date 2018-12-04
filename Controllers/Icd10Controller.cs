using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FMBPublic.Model;
using FMBPublic.Services;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FMBPublic.Controllers
{
    public class Icd10Controller : Controller
    {
        [HttpGet]
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(Icd10SearchRequest Request)
        {
            Icd10Service Iicd10Service = new Icd10Service(Connection.GetCs().GetConnection());
            var res = Iicd10Service.SearchIcd10(Request);
            return View(res);
        }
    }
}
