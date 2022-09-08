using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        private DbPersonelEntities dbPersonelEntities = new DbPersonelEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult BannerPartial()
        {
            return PartialView();
        }

        public PartialViewResult SkillPartial()
        {
            var skills = dbPersonelEntities.TblSkill.ToList();
            return PartialView(skills);
        }

        public PartialViewResult FeaturePartial()
        {
            return PartialView();
        }

        public PartialViewResult ImagePartial()
        {
            var value = (from x in dbPersonelEntities.TblExperience select x);
            ViewBag.v1 = value;
            var categories = dbPersonelEntities.TblImage.Select(x => x.Category).Distinct().ToList();
            ViewBag.categories = categories;
            ViewBag.v = "C# ve .Net alanında yapmış olduğum projelere ait görsellere aşağıdan ulaşabilirsiniz, daha fazlası için iletişim kısmından bana yazabilirsiniz.";
            var images = dbPersonelEntities.TblImage.ToList();
            return PartialView(images);
        }

        public PartialViewResult ExperiencePartial()
        {
            return PartialView();
        }

        public PartialViewResult EducationPartial()
        {
            return PartialView();
        }

        public PartialViewResult TestimonialPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}