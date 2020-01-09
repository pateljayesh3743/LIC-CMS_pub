using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIC_CMS.Models;
using LIC_CMS.Controllers;
using LIC_CMS.Areas.Admin.Models;

namespace LIC_CMS.Areas.Admin.Controllers
{
    [Authorise(Roles="ADM")]
    public class ModeController : Controller
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
            return View(ModeModel.getAllMode());
        }
        [HttpPost]
        public ActionResult Create(ModeModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.MODE_ID == 0)
                {
                    ModeModel.insertMode(model);
                    ModelState.Clear();
                    return Json("Save mode successfully.", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ModeModel.updateMode(model);
                    ModelState.Clear();
                    return Json("Update mode successfully.", JsonRequestBehavior.AllowGet);
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
            return Json(ModeModel.getModeById(id), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var query = db.MODE_MASTER.Where(x => x.MODE_ID == id).FirstOrDefault();
                db.MODE_MASTER.Remove(query);
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