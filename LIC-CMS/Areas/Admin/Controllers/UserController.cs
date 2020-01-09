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
    public class UserController : Controller
    {
        LIC_CMSEntities db = new LIC_CMSEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetGrid()
        {
            return View(UserModel.getUserList());
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.USER_ID == 0)
                {
                    UserModel.insertUser(model);
                    ModelState.Clear();
                    return Json("User successfully Save.", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    UserModel.updateUser(model);
                    ModelState.Clear();
                    return Json("User successfully Updated.", JsonRequestBehavior.AllowGet);
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
            if (id != null && id != 0)
            {
                return Json(UserModel.getUserById(id), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Delete(int? id)
        {
            if (id != null && id != 0)
            {
                var search = db.USER_MASTER.Where(x => x.USER_ID_ == id).FirstOrDefault();
                search.IS_ACTIVE = 0;
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