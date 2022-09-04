using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        private DbPersonelEntities dbPersonelEntities = new DbPersonelEntities();
        public ActionResult Index()
        {
            var skills = dbPersonelEntities.TblSkill.ToList();
            return View(skills);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(TblSkill skill)
        {
            dbPersonelEntities.TblSkill.Add(skill);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = dbPersonelEntities.TblSkill.Where(x => x.SkillID == id).FirstOrDefault();
            dbPersonelEntities.TblSkill.Remove(value);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var value = dbPersonelEntities.TblSkill.Where(x => x.SkillID == id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public ActionResult EditSkill(TblSkill s)
        {
            var skill = dbPersonelEntities.TblSkill.Find(s.SkillID);
            skill.SkillID = s.SkillID;
            skill.SkillTitle = s.SkillTitle;
            skill.SkillValue = s.SkillValue;
            dbPersonelEntities.TblSkill.AddOrUpdate(skill);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}