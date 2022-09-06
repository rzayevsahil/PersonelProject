using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        DbPersonelEntities dbPersonelEntities = new DbPersonelEntities();
        public ActionResult Index()
        {
            var testimonials = dbPersonelEntities.TblTestimonial.ToList();
            return View(testimonials);
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial testimonial)
        {
            dbPersonelEntities.TblTestimonial.Add(testimonial);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var testimonial = dbPersonelEntities.TblTestimonial.Find(id);
            dbPersonelEntities.TblTestimonial.Remove(testimonial);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTestimonial(int id)
        {
            var testimonial = dbPersonelEntities.TblTestimonial.Find(id);
            return View(testimonial);
        }

        [HttpPost]
        public ActionResult EditTestimonial(TblTestimonial t)
        {
            var testimonial = dbPersonelEntities.TblTestimonial.Find(t.TestimonialID);
            testimonial.TestimonialID = t.TestimonialID;
            testimonial.TestimonialName = t.TestimonialName;
            testimonial.TestimonialImage = t.TestimonialImage;
            testimonial.TestimonialTitle = t.TestimonialTitle;
            testimonial.TestimonialDescription = t.TestimonialDescription;
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}