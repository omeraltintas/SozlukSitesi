﻿using BusinessLayer.Concrete;
using DAL.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        public ActionResult HeadingReport()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString(),
                                                  }
                                                ).ToList();
            List<SelectListItem> valuewriter=(from x in wm.GetList()
                                              select new SelectListItem
                                              { 
                                                  Text=x.WriterName+" "+x.WriterSurname,
                                                  Value=x.WriterID.ToString()
                                              }).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString(),
                                                  }
                                             ).ToList();
            ViewBag.vlc = valuecategory;
            var headingvalue = hm.GetById(id);
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = hm.GetById(id);
            headingvalue.HeadingStatus = false;
            hm.HeadingDelete(headingvalue);
            return RedirectToAction("Index");
        }
    }
}