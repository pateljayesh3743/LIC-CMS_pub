using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIC_CMS.Models;
using LIC_CMS.Areas.Admin.Models;
using LIC_CMS.Controllers;

namespace LIC_CMS.Areas.Admin.Controllers
{

    public class CityController : Controller
    {
        LIC_CMSEntities db = new LIC_CMSEntities();

        [Authorise(Roles = "ADM")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorise(Roles = "ADM")]
        public ActionResult GetGrid()
        {
            return View(CityModel.getCity());
        }

        [HttpGet]
        [Authorise(Roles = "USR,ADM")]
        public JsonResult FillState(int countryid)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var state = db.STATE_MASTER.Where(x => x.COUNTRY_ID == countryid).ToList();
            if (state != null)
            {
                foreach (var item in state)
                {
                    list.Add(new SelectListItem
                    {
                        Text = item.STATE_NAME,
                        Value = item.STATE_ID.ToString()
                    });
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Authorise(Roles = "USR,ADM")]
        public JsonResult FillCity(int stateid)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var city = db.CITY_MASTER.Where(x => x.STATE_ID == stateid).ToList();
            if (city != null)
            {
                foreach (var item in city)
                {
                    list.Add(new SelectListItem
                    {
                        Text = item.CITY_NAME,
                        Value = item.CITY_ID.ToString()
                    });
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Authorise(Roles = "ADM")]
        public ActionResult Create()
        {
            return View(new CityModel());
        }
        [HttpPost]
        public ActionResult Create(CityModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.CITY_ID == 0)
                {
                    CityModel.insertCity(model);
                    ModelState.Clear();
                    return Json("City save successfully.", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    CityModel.updateCity(model);
                    ModelState.Clear();
                    return Json("City update successfully.", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("Please fill all fields.", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        [Authorise(Roles = "ADM")]
        public JsonResult Edit(int? id)
        {
            if (id != 0)
            {
                return Json(CityModel.getCityById(id), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [Authorise(Roles = "ADM")]
        public ActionResult Delete(int? id)
        {
            if (id != 0)
            {
                var query = db.CITY_MASTER.Where(x => x.CITY_ID == id).FirstOrDefault();
                db.CITY_MASTER.Remove(query);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}