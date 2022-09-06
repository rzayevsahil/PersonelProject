using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personel_Demo.Models;

namespace Project_Personel_Demo.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature
        DbPersonelEntities dbPersonelEntities = new DbPersonelEntities();
        public ActionResult Index()
        {
            var features = dbPersonelEntities.TblFeature.ToList();
            return View(features);
        }

        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFeature(TblFeature f)
        {
            dbPersonelEntities.TblFeature.Add(f);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id)
        {
            var feature = dbPersonelEntities.TblFeature.Find(id);
            dbPersonelEntities.TblFeature.Remove(feature);
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditFeature(int id)
        {
            var feature = dbPersonelEntities.TblFeature.Find(id);
            return View(feature);
        }
        [HttpPost]
        public ActionResult EditFeature(TblFeature f)
        {
            var feature = dbPersonelEntities.TblFeature.Find(f.FeatureID);
            feature.FeatureID = f.FeatureID;
            feature.FeatureTitle = f.FeatureTitle;
            feature.FeatureLogo = f.FeatureLogo;
            feature.FeatureDescription = f.FeatureDescription;
            dbPersonelEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}