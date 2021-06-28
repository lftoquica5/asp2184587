﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp2184587.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Acerca de nosotros.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Tu pagina de contacto.";

            return View();
        }
    }
}