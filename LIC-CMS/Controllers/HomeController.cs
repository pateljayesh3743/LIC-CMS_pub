using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIC_CMS.Models;

namespace LIC_CMS.Controllers
{
    [Authorise(Roles = "USR")]
    public class HomeController : Controller
    {
        LIC_CMSEntities db = new LIC_CMSEntities();
        public ActionResult Index()
        {
            var search = db.USER_DETAIL_MASTER.Where(x => x.USER_ID == SessionWrapper.UserId);
            if (search == null)
            {
                return RedirectToAction("Create", "UserDetail");
            }
            else
            {
                var Client = db.CLIENT_MASTER.Count(x => x.IS_DELETE == false).ToString();
                ViewBag.Client = Client;
                //var Mode = db.MODE_MASTER.Count().ToString();
                //ViewBag.Mode = Mode;
                //var Term = db.TERM_MASTER.Count().ToString();
                //ViewBag.Term = Term;
                return View();
            }
        }

       

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}