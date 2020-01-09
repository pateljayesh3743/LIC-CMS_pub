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
    [Authorise(Roles="ADM")]
    public class TermController : Controller
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
            return View(TermModel.getAllTerm());
        }
        [HttpPost]
        public ActionResult Create(TermModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.TERM_ID == 0)
                {
                    TermModel.insertTerm(model);
                    ModelState.Clear();
                    return Json("Save term successfully.", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    TermModel.updateTerm(model);
                    ModelState.Clear();
                    return Json("Update term successfully.", JsonRequestBehavior.AllowGet);
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
            return Json(TermModel.getTermById(id),JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var query = db.TERM_MASTER.Where(x => x.TERM_ID == id).FirstOrDefault();
                db.TERM_MASTER.Remove(query);
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