using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Areas.Member.Controllers
{
    public class LoginController : Controller
    {
        // GET: Member/Login

        DbPersonelEntities dbPersonelEntities = new DbPersonelEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblMember member)
        {
            var members = dbPersonelEntities.TblMember.FirstOrDefault(x =>
                x.MemberMail == member.MemberMail && x.MemberPassword == member.MemberPassword);
            if (members != null)
            {
                FormsAuthentication.SetAuthCookie(members.MemberMail,false);
                Session["MemberMail"] = members.MemberMail;
                return RedirectToAction("EditProfile", "Profile");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}