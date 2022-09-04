using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
         DbPersonelEntities dbPersonelEntities = new DbPersonelEntities();
        public ActionResult Index()
        {
            var educations = dbPersonelEntities.TblEducation.ToList();
            return View(educations);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblEducation education)
        {
            dbPersonelEntities.TblEducation.Add(education);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }   

        public ActionResult DeleteEducation(int id)
        {
            var education = dbPersonelEntities.TblEducation.Find(id);
            dbPersonelEntities.TblEducation.Remove(education);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var education = dbPersonelEntities.TblEducation.Find(id);
            ViewBag.date = education.EduationDate;
            return View(education);
        }

        [HttpPost]
        public ActionResult EditEducation(TblEducation e)
        {
            var education = dbPersonelEntities.TblEducation.Find(e.EducationID);
            education.EducationID = e.EducationID;
            education.EducationTitle = e.EducationTitle;
            education.EduationDate = e.EduationDate;
            education.EducationDescription = e.EducationDescription;
            dbPersonelEntities.TblEducation.AddOrUpdate(education);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}