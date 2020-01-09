using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIC_CMS.Controllers;
using LIC_CMS.Models;
using LIC_CMS.Areas.Admin.Models;

namespace LIC_CMS.Areas.Admin.Controllers
{
    [Authorise(Roles = "ADM")]
    public class CountryController : Controller
    {
        LIC_CMSEntities db = new LIC_CMSEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetGrid()
        {
            return View(CountryModel.getCountry());
        }
        [HttpPost]
        public ActionResult Create(CountryModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.COUNTRY_ID == 0)
                {
                    bool valid = CountryModel.insertCountry(model);
                    if (valid)
                    {
                        ModelState.Clear();
                        return Json("Save Country successfully.", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Issue in Save.", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    bool valid = CountryModel.updateCountry(model);
                    if (valid)
                    {
                        ModelState.Clear();
                        return Json("Update Country successfully.", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Issue in Save.", JsonRequestBehavior.AllowGet);
                    }
                }

            }
            else
            {
                return Json("Please fill all fields.", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult Edit(int? id)
        {
            if (id != 0 && id != null)
            {
                return Json(CountryModel.getCountryById(id), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null && id != 0)
            {
                var query = db.COUNTRY_MASTER.Where(x => x.COUNTRY_ID == id).FirstOrDefault();
                db.COUNTRY_MASTER.Remove(query);
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