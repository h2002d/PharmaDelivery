using PharmaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaDelivery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       // [Authorize(Roles = "Administrator")]
        public ActionResult AddDrug()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var groups = Group.GetGroupById(null);
            //foreach (var item in groups) {
            //    items.Add(new SelectListItem { Value = item.id.ToString(), Text = item.Name });
            //}
            ViewBag.Groups = groups;
            return View();
        }

        public ActionResult GetSubGroupById(int id)
        {
            var subgroups = SubGroup.GetSubGroupByParentId(id);
            return Json(subgroups, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPreparateBySubId(int id)
        {
            var preparates = Preparate.GetPreparatesById(id);
            return Json(preparates, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveDrug(Drug drug)
        {
            try
            {
                drug.SaveDrug();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("AddDrug", "Home");
            }
        }

        public ActionResult AddPreparate()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var groups = Group.GetGroupById(null);
            //foreach (var item in groups) {
            //    items.Add(new SelectListItem { Value = item.id.ToString(), Text = item.Name });
            //}
            ViewBag.Groups = groups;
            return View();
        }
        [HttpPost]
        public ActionResult SavePreparate(Preparate preparate)
        {
            try
            {
                preparate.Save();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("AddPreparate", "Home");
            }
        }
    }
}