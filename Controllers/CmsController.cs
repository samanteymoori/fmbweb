﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMBPublic.Controllers
{
    public class CmsController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
