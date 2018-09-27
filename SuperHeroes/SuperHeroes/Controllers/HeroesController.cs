using SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class HeroesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //public Heroes GetHeroById(int id)
        //{
        //    Heroes hero;
        //    // query for hero by ID
        //    return hero;
        //}
        // GET: Heroes
        public ActionResult Index()
        {
            //could add . where after Heroes to narrow search
            var heroes = db.Heroes;
            return View(heroes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Heroes hero)
        {
            if (ModelState.IsValid)
            {
                db.Heroes.Add(hero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            //ViewBag.Name = new SelectList(db.Heroes, "ID", "Name", hero.Name);
            return View(hero);
        }
    }
}