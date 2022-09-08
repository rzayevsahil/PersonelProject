using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        DbPersonelEntities db = new DbPersonelEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult StatisticsPartial()
        {
            ViewBag.v1 = db.TblSkill.Count();
            ViewBag.v2 = db.TblImage.Where(x => x.Category == "C#").Count();
            int id = db.TblExperience.Max(x => x.ExperienceID);
            ViewBag.v3 = db.TblExperience.Where(x => x.ExperienceID == id).Select(y => y.ExperienceDescription).FirstOrDefault();
            ViewBag.v4 = db.TblExperience.Where(x => x.ExperinceTitle == "Eğitmen").Count();
            return PartialView();
        }
    }
}