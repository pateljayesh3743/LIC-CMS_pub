using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIC_CMS.Models;
using LIC_CMS.Controllers;

namespace LIC_CMS.Areas.Admin.Controllers
{
    [Authorise(Roles = "ADM")]
    public class DashboardController : Controller
    {
        LIC_CMSEntities db = new LIC_CMSEntities();
        public ActionResult Index()
        {
            ViewBag.UserCount = db.USER_MASTER.Count().ToString();
            ViewBag.CountryCount = db.COUNTRY_MASTER.Count().ToString();
            ViewBag.StateCount = db.STATE_MASTER.Count().ToString();
            ViewBag.CityCount = db.CITY_MASTER.Count().ToString();
            ViewBag.PlanCount = db.PLAN_MASTER.Count().ToString();
            ViewBag.TermCount = db.TERM_MASTER.Count().ToString();
            ViewBag.ModeCount = db.MODE_MASTER.Count().ToString();
            return View();
        }
	}
}