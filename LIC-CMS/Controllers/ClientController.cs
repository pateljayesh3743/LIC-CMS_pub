using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIC_CMS.Models;

namespace LIC_CMS.Controllers
{
    [Authorise(Roles = "USR")]
    public class ClientController : Controller
    {
        // GET: Client
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ClientAssuranceModel());
        }

        [HttpGet]
        public ActionResult Gird()
        {
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                ViewBag.Client = db.spGetClientMaster(null).ToList();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(ClientAssuranceModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.CLIENT_ID == 0)
                {
                    using (LIC_CMSEntities db = new LIC_CMSEntities())
                    {
                        model.USER_ID = SessionWrapper.UserId;

                        db.spCreateClientMaster(model.FIRST_NAME, model.LAST_NAME, model.MIDDLE_NAME, model.DOB, model.AGE, model.MOBILE, model.EMAIL, model.DOS, model.WEIGHT, model.HEIGHT, model.IDENTITY_OF_BODY, model.AADDRESS, model.PIN_CODE, model.CITY_ID, model.USER_ID,true,false,model.USER_ID, System.DateTime.Now);

                        model.CLIENT_ID = db.CLIENT_MASTER.Max(x => x.CLIENT_ID);

                        db.spCreateClientAssuranceMaster(model.PREMIUM,model.POLICY_NUMBER,model.SUM_OF_ASSURANCE,model.PLAN_ID,model.MODE_ID,model.TERM_ID,model.DATE_OF_MATURITY,System.DateTime.Now,model.NOMINEE,model.CLIENT_ID,true,false,model.USER_ID,System.DateTime.Now);

                        ModelState.Clear();
                        return Json("Save Country successfully.", JsonRequestBehavior.AllowGet);   
                    }
                }
                else
                {
                    using(LIC_CMSEntities db=new LIC_CMSEntities())
                    {
                     
                        db.spUpdateClientMaster(model.CLIENT_ID,model.FIRST_NAME, model.LAST_NAME, model.MIDDLE_NAME, model.DOB, model.AGE, model.MOBILE, model.EMAIL, model.DOS, model.WEIGHT, model.HEIGHT, model.IDENTITY_OF_BODY, model.AADDRESS, model.PIN_CODE, model.CITY_ID, model.USER_ID,true,false,model.USER_ID,System.DateTime.Now);

                        db.spUpdateClientAssuranceMaster(model.CLIENTASSURANCE_ID,model.PREMIUM, model.POLICY_NUMBER, model.SUM_OF_ASSURANCE, model.PLAN_ID, model.MODE_ID, model.TERM_ID, model.DATE_OF_MATURITY, model.NEXT_PREMIUM_DATE, model.NOMINEE, model.CLIENT_ID, true, false, model.USER_ID, System.DateTime.Now);

                        ModelState.Clear();
                        return Json("Update Country successfully.", JsonRequestBehavior.AllowGet);
                    }
                }

            }
            else
            {
                return Json("Please fill all fields.", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Edit(int ? id)
        {
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                var search = db.spGetClientMaster(id).FirstOrDefault();
                 return Json(new ClientAssuranceModel
                {
                    CLIENT_ID = search.CLIENT_ID,
                    FIRST_NAME = search.FIRST_NAME,
                    MIDDLE_NAME = search.MIDDLE_NAME,
                    LAST_NAME = search.LAST_NAME,
                    DOB = Convert.ToDateTime(search.DOB),
                    MOBILE = search.MOBILE,
                    EMAIL = search.EMAIL,
                    HEIGHT = Convert.ToSingle(search.HEIGHT),
                    WEIGHT = Convert.ToSingle(search.WEIGHT),
                    DATE_OF_MATURITY = Convert.ToDateTime(search.DATE_OF_MATURITY),
                    DOS = Convert.ToDateTime(search.DOS),
                    IDENTITY_OF_BODY = search.IDENTITY_OF_BODY,
                    NEXT_PREMIUM_DATE = Convert.ToDateTime(search.NEXT_PREMIUM_DATE),
                    CITY_ID=Convert.ToInt32(search.CITY_ID),
                    USER_ID = Convert.ToInt32(search.USER_ID),
                    AGE=Convert.ToInt32(search.AGE),
                    PIN_CODE=search.PIN_CODE,
                    AADDRESS=search.ADDRESS,
                    STATE_ID=Convert.ToInt32(search.STATE_ID),
                    COUNTRY_ID = Convert.ToInt32(search.COUNTRY_ID),


                    MODE_ID=Convert.ToInt32(search.MODE_ID),
                    PLAN_ID=Convert.ToInt32(search.PLAN_ID),
                    TERM_ID=Convert.ToInt32(search.TERM_ID),
                    CLIENTASSURANCE_ID = search.CLIENTASSURANCE_ID,
                    PREMIUM =Convert.ToSingle(search.PREMIUM),
                    POLICY_NUMBER = search.POLICY_NUMBER,
                    SUM_OF_ASSURANCE = Convert.ToSingle(search.SUM_OF_ASSURANCE),
                    NOMINEE=search.NOMINEE
                },JsonRequestBehavior.AllowGet);
            }
        }
    }
}