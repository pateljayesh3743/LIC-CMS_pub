using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIC_CMS.Areas.Admin.Models;
using LIC_CMS.Controllers;
using LIC_CMS.Models;

namespace LIC_CMS.Areas.Admin.Controllers
{
    [Authorise(Roles = "ADM")]
    public class StateController : Controller
    {
        LIC_CMSEntities db = new LIC_CMSEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetGrid()
        {
            return View(StateModel.getState());
        }
        [HttpPost]
        public ActionResult Create(StateModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.STATE_ID == 0)
                {
                    StateModel.insertState(model);
                    ModelState.Clear();
                    return Json("Save State successfully.", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    StateModel.updateState(model);
                    ModelState.Clear();
                    return Json("Update State successfully.", JsonRequestBehavior.AllowGet);
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
            if (id != 0)
            {
                return Json(StateModel.getStateById(id), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != 0)
            {
                var query = db.STATE_MASTER.Where(x => x.STATE_ID == id).FirstOrDefault();
                db.STATE_MASTER.Remove(query);
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