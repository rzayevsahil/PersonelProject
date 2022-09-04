using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        DbPersonelEntities dbPersonelEntities = new DbPersonelEntities();
        public ActionResult Index()
        {
            var experiences = dbPersonelEntities.TblExperience.ToList();
            return View(experiences);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(TblExperience experience)
        {
            dbPersonelEntities.TblExperience.Add(experience);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            var value = dbPersonelEntities.TblExperience.Where(x => x.ExperienceID == id).FirstOrDefault();
            dbPersonelEntities.TblExperience.Remove(value);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }
            
        [HttpGet]
        public ActionResult EditExperience(int id)
        {
            var value = dbPersonelEntities.TblExperience.Where(x => x.ExperienceID == id).FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public ActionResult EditExperience(TblExperience experience)
        {
            var value = dbPersonelEntities.TblExperience.Where(x => x.ExperienceID == experience.ExperienceID).FirstOrDefault();
            value.ExperienceID = experience.ExperienceID;
            value.ExperinceTitle= experience.ExperinceTitle;
            value.ExperienceDescription = experience.ExperienceDescription;
            value.ExperienceDate = experience.ExperienceDate;
            dbPersonelEntities.TblExperience.AddOrUpdate(value);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}