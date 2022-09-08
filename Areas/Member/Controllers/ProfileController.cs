using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Areas.Member.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Member/Profile
        private DbPersonelEntities dbPersonelEntities = new DbPersonelEntities();
        public ActionResult Index()
        {
            var mail = Session["MemberMail"];
            ViewBag.user = dbPersonelEntities.TblMember.Where(x=>x.MemberMail==mail).Select(x=>x.MemberName+" "+x.MemberSurname).FirstOrDefault();

            return View();
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            var mail = Session["MemberMail"];
            var user = dbPersonelEntities.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            return View(user);
        }


        [HttpPost]
        public ActionResult EditProfile(TblMember tblMember)
        {
            var mail = Session["MemberMail"];
            var user = dbPersonelEntities.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            user.MemberName = tblMember.MemberName;
            user.MemberSurname = tblMember.MemberSurname;
            user.MemberMail = tblMember.MemberMail;
            user.MemberPassword = tblMember.MemberPassword;
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}