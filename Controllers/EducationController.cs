using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
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
        string startDateYear, endDateYear, startDateMonth, endDateMonth;

        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var education = dbPersonelEntities.TblEducation.Find(id);
            ViewBag.date = education.EduationDate;

            List<string> months = new List<string>();
            months.Add("Ocak");
            months.Add("Şubat");
            months.Add("Mart");
            months.Add("Nisan");
            months.Add("Mayıs");
            months.Add("Haziran");
            months.Add("Temmuz");
            months.Add("Ağustos");
            months.Add("Eylül");
            months.Add("Ekim");
            months.Add("Kasım");
            months.Add("Aralık");

            //tarihleri alıp arada tire var diye bölüyorum(start,end)
            var startDate = education.EduationDate.Split('-')[0];
            var endDate = education.EduationDate.Split('-')[1];
            for (int i = 0; i < months.Count; i++)
            {
                if (startDate.Contains(months[i]))
                {
                    if (i < 10)
                        startDateMonth = "0" + (i + 1);
                    else
                        startDateMonth = (i + 1).ToString();
                }
                if (endDate.Contains(months[i]))
                {
                    if (i < 10)
                        endDateMonth = "0" + (i + 1);
                    else
                        endDateMonth = (i + 1).ToString();

                }
            }

            for (int i = 0; i < startDate.Length; i++)
            {
                if (Char.IsNumber(startDate[i]))
                {
                    startDateYear += startDate[i].ToString();
                }
            }

            for (int i = 0; i < endDate.Length; i++)
            {
                if (Char.IsNumber(endDate[i]))
                {
                    endDateYear += endDate[i].ToString();
                }
            }

            ViewBag.startDate = startDateYear + "-" + startDateMonth;
            ViewBag.endDate = endDateYear + "-" + endDateMonth;
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