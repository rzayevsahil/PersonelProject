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

        string startDateYear, endDateYear, startDateMonth, endDateMonth;

        [HttpGet]
        public ActionResult EditExperience(int id)
        {
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
            var experience = dbPersonelEntities.TblExperience.Where(x => x.ExperienceID == id).FirstOrDefault();

            //tarihleri alıp arada tire var diye bölüyorum(start,end)
            var startDate = experience.ExperienceDate.Split('-')[0];
            var endDate = experience.ExperienceDate.Split('-')[1];
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

            return View(experience);
        }
        [HttpPost]
        public ActionResult EditExperience(TblExperience experience)
        {
            var value = dbPersonelEntities.TblExperience.Where(x => x.ExperienceID == experience.ExperienceID).FirstOrDefault();
            value.ExperienceID = experience.ExperienceID;
            value.ExperinceTitle = experience.ExperinceTitle;
            value.ExperienceDescription = experience.ExperienceDescription;
            value.ExperienceDate = experience.ExperienceDate;
            dbPersonelEntities.TblExperience.AddOrUpdate(value);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}