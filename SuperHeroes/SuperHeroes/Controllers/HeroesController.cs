﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class HeroesController : Controller
    {
        // GET: Heroes
        public ActionResult Index()
        {
            return View();
        }
    }
}