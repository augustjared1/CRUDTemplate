using SportsDB.Models;
using SportsDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsDB.DataModels;

namespace SportsDB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            HomeIndexVM bucket = new HomeIndexVM();

            if (searchString != null)
            {
                bucket.Athletes = db.Athletes.Include("Sports")
                                             .Where(c => c.Name.Contains(searchString))
                                             .ToList();
            }
            else
            {
                bucket.Athletes = db.Athletes.ToList();
                bucket.Sports = db.Sports.ToList();
            }

            return View(bucket);
        }

        [HttpGet]
        public ActionResult NewAthlete()
        {
             return View();
        }

        [HttpPost]
        public ActionResult NewAthlete(Athlete newathlete)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            HomeIndexVM bucket = new HomeIndexVM();

            db.Athletes.Add(newathlete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAthlete(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            HomeIndexVM bucket = new HomeIndexVM();

            bucket.Athletes = db.Athletes.Where(c => c.id == id).ToList();

            return View(bucket);
        }

        [HttpPatch] //maybe HttpPost
        public ActionResult UpdateAthlete(int id, Athlete updatedathlete)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            HomeIndexVM bucket = new HomeIndexVM();
            Athlete Athlete = new Athlete();

            Athlete = db.Athletes.Find(id);
            Athlete.Name = updatedathlete.Name;
            Athlete.Position = updatedathlete.Position;
            Athlete.Team = updatedathlete.Team;

            db.SaveChanges();

            return View(bucket);
        }

        [HttpGet]
        public ActionResult DeleteAthlete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteAthlete(int id, string DeleteAthlete)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            HomeIndexVM bucket = new HomeIndexVM();
            Athlete deleteathlete = db.Athletes.Find(id);

            db.Athletes.Remove(deleteathlete);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "To learn more about these Athletes, please visit Wikipedia";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You may find more valuable content at http://www.9gag.com";

            return View();
        }
    }
}