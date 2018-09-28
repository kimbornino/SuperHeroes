using SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        public ActionResult Create()
        {
            //ViewBag.Name = new SelectList(db.Heroes, "ID", "Name", hero.ID);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name, AlterEgo, PrimaryAbility, SecondaryAbility, Catchphrase")] Heroes hero)
        {
            if (ModelState.IsValid)
            {
                db.Heroes.Add(hero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.Name = new SelectList(db.Heroes, "ID","Name", hero.ID);
            return View(hero);
        }
        public ActionResult Edit(int ID = 0)
        {
            var heroes = db.Heroes.Find(ID);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Heroes hero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hero);
        }
        public ActionResult Details (int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var heroes = db.Heroes.Find(ID);
            if (heroes == null)
            {
                return HttpNotFound();
            }
            return View(heroes);
        }
        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var heroes = db.Heroes.Find(id);
            if (heroes == null)
            {
                return HttpNotFound();
            }
            return View(heroes);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var heroes = db.Heroes.Find(id);
            db.Heroes.Remove(heroes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}