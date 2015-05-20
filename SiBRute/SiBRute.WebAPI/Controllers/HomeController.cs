﻿using SiBRute.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiBRute.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private ITestDI testDI;

        public HomeController(ITestDI testDI)
        {
            this.testDI = testDI;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.String = testDI.GetData();
            return View();
        }
    }
}