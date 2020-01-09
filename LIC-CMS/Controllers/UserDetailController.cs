using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIC_CMS.Models;

namespace LIC_CMS.Controllers
{
    [Authorise(Roles="USR")]
    public class UserDetailController : Controller
    {
        LIC_CMSEntities db = new LIC_CMSEntities();
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new UserDetailModel());
        }
        [HttpPost]
        public ActionResult Create(UserDetailModel model,HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                USER_DETAIL_MASTER userdetail=new USER_DETAIL_MASTER();
                userdetail.FIRST_NAME  = model.FIRST_NAME;
                userdetail.MIDDLE_NAME = model.MIDDLE_NAME;
                userdetail.LAST_NAME   = model.LAST_NAME;
                userdetail.PIN_CODE    = model.PIN_CODE;
                userdetail.AGENT_CODE  = model.AGENT_CODE;
                userdetail.CITY_ID     = model.CITY_ID;
                userdetail.ADDRESS     = model.ADDRESS;
                userdetail.EMAIL       = model.EMAIL;
                userdetail.MOBILE      = model.MOBILE;
                userdetail.USER_ID     = SessionWrapper.UserId;

                db.USER_DETAIL_MASTER.Add(userdetail);
                db.SaveChanges();


                var file = Request.Files["photo"];
                var path = Server.MapPath("~/Content/assets/Images/");
                file.SaveAs(path + userdetail.USER_DETAIL_ID + ".png");

                ModelState.Clear();
                ViewBag.Message = "Profile detail save successfully.";
                return View(new UserDetailModel());
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            var search = db.USER_DETAIL_MASTER.Where(x => x.USER_ID == id).FirstOrDefault();
            var state = db.CITY_MASTER.Where(x => x.CITY_ID == search.CITY_ID).FirstOrDefault();
            var country = db.STATE_MASTER.Where(x => x.STATE_ID == state.STATE_ID).FirstOrDefault();
            return View(new UserDetailModel {
                USER_ID = Convert.ToInt32(search.USER_ID),
                USER_DETAIL_ID=search.USER_DETAIL_ID,
                ADDRESS=search.ADDRESS,
                CITY_ID=Convert.ToInt32(search.CITY_ID),
                FIRST_NAME=search.FIRST_NAME,
                LAST_NAME=search.LAST_NAME,
                EMAIL=search.EMAIL,
                AGENT_CODE=search.AGENT_CODE,
                MIDDLE_NAME=search.MIDDLE_NAME,
                PIN_CODE=search.PIN_CODE,
                MOBILE=search.MOBILE,
                STATE_ID=Convert.ToInt32(state.STATE_ID),
                COUNTRY_ID=Convert.ToInt32(country.COUNTRY_ID)
            });
        }

        [HttpGet]
        public ActionResult Edit(int ? id)
        {
            var search = db.USER_DETAIL_MASTER.Where(x => x.USER_DETAIL_ID == id).FirstOrDefault();
            var state = db.CITY_MASTER.Where(x => x.CITY_ID == search.CITY_ID).FirstOrDefault();
            var country = db.STATE_MASTER.Where(x => x.STATE_ID == state.STATE_ID).FirstOrDefault();
            return View(new UserDetailModel
            {
                USER_ID = Convert.ToInt32(search.USER_ID),
                USER_DETAIL_ID = search.USER_DETAIL_ID,
                ADDRESS = search.ADDRESS,
                CITY_ID = Convert.ToInt32(search.CITY_ID),
                FIRST_NAME = search.FIRST_NAME,
                LAST_NAME = search.LAST_NAME,
                EMAIL = search.EMAIL,
                AGENT_CODE = search.AGENT_CODE,
                MIDDLE_NAME = search.MIDDLE_NAME,
                PIN_CODE = search.PIN_CODE,
                MOBILE = search.MOBILE,
                STATE_ID = Convert.ToInt32(state.STATE_ID),
                COUNTRY_ID = Convert.ToInt32(country.COUNTRY_ID)
            });
        }
	}
}