using Project_Personel_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Personel_Demo.Areas.Member.Controllers
{
    public class BanPageController : Controller
    {
        // GET: Member/BanPage
        DbPersonelEntities dbPersonelEntities = new DbPersonelEntities();
        public ActionResult BanPage(int id)
        {
            var member = dbPersonelEntities.TblMember.Find(id);
            var banTimeHour = Convert.ToDateTime(member.LockoutEnd).Hour - DateTime.Now.Hour;
            var banTimeDay = Convert.ToDateTime(member.LockoutEnd).Day - DateTime.Now.Day;
            ViewBag.banTimeHour = banTimeHour;
            ViewBag.banTimeDay = banTimeDay;
            return View();
        }
    }
}