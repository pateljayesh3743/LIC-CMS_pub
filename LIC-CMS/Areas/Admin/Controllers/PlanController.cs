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
    [Authorise(Roles = "ADM")]
    public class PlanController : Controller
    {
        LIC_CMSEntities db = new LIC_CMSEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetGrid()
        {
            return View(PlanModel.getAllPlan());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new PlanModel());
        }
        [HttpPost]
        public ActionResult Create(PlanModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.PLAN_ID == 0)
                {
                    PlanModel.insertPlan(model);
                    ModelState.Clear();
                    return Json("Save Plan Successfully.",JsonRequestBehavior.AllowGet);
                }
                else
                {
                    PlanModel.updatePlan(model);
                    ModelState.Clear();
                    return Json("Update Plan successfully.", JsonRequestBehavior.AllowGet);
                }
                
            }
            else
            {
                return Json("Please fill all fields.", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult Edit(int ? id)
        {
            return Json(PlanModel.getPlanById(id),JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Delete(int ? id)
        {
            if(id != null)
            {
                var query = db.PLAN_MASTER.Where(x => x.PLAN_ID == id).FirstOrDefault();
                db.PLAN_MASTER.Remove(query);
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