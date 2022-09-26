using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json.Linq;
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
            if (members != null && members.LockoutEnabled)
            {
                FormsAuthentication.SetAuthCookie(members.MemberMail, false);
                Session["MemberMail"] = members.MemberMail;
                return RedirectToAction("EditProfile", "Profile");
            }
            else if (members != null && !members.LockoutEnabled)
            {
                var banTimeMinute = Convert.ToDateTime(member.LockoutEnd).Subtract(DateTime.Now).Minutes;
                var banTimeHour = Convert.ToDateTime(member.LockoutEnd).Subtract(DateTime.Now).Hours;
                var banTimeDay = Convert.ToDateTime(member.LockoutEnd).Subtract(DateTime.Now).Days;

                
                if(banTimeDay.Equals(0) && banTimeHour.Equals(0))
                {
                    members.LockoutEnabled = true;
                    members.LockoutEnd = null;
                    members.AccessFailedCount = 0;
                    dbPersonelEntities.SaveChanges();
                    FormsAuthentication.SetAuthCookie(members.MemberMail, false);
                    Session["MemberMail"] = members.MemberMail;
                    return RedirectToAction("EditProfile", "Profile");
                }
                else
                {
                    return RedirectToAction("BanPage/" + members.MemberID, "BanPage");
                }

            }
            else
            {
                var selectUser = dbPersonelEntities.TblMember.FirstOrDefault(x => x.MemberMail == member.MemberMail);
                if (selectUser?.AccessFailedCount < 3)
                {
                    selectUser.AccessFailedCount += 1;
                    if (selectUser?.AccessFailedCount==3)
                    {
                        selectUser.LockoutEnabled = false;
                        DateTime date = DateTime.Now;
                        TimeSpan banTime = new TimeSpan(3, 0, 0, 0);
                        var banTimeEnd = date.Add(banTime);
                        selectUser.LockoutEnd = banTimeEnd;
                    }
                    dbPersonelEntities.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    return RedirectToAction("BanPage/" + selectUser.MemberID, "BanPage");
                }

            }
        }

        public ActionResult LogOut()
        {
            return RedirectToAction("Index");
        }
    }
}