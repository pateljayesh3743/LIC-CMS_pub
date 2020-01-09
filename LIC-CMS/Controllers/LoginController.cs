using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIC_CMS.Models;

namespace LIC_CMS.Controllers
{
    public class LoginController : Controller
    {
        LIC_CMSEntities db = new LIC_CMSEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var result = db.USER_MASTER.Where(x => x.USER_NAME == model.USER_NAME && x.IS_ACTIVE ==1).FirstOrDefault();
                if(result !=null)
                {
                    if(System.Web.Helpers.Crypto.VerifyHashedPassword(result.PASSWORD,model.PASSWORD))
                    {
                        SessionWrapper.RoleName = result.ROLE_ABBR;
                        SessionWrapper.UserName = result.USER_NAME;
                        SessionWrapper.UserId = Convert.ToInt32(result.USER_ID_);

                        if (result.ROLE_ABBR == "ADM")
                        {
                            return Redirect("~/Admin/Dashboard");
                        }
                        else
                        {
                            return Redirect("~/Home");
                        }
                    }
                }
                else
                {
                    ViewBag.Message = "User Name and Password incorrect.";
                    return View(model);
                }
            }

            ViewBag.Message = "Please Try agin.";
            return View(model);     
            
        }

        [HttpGet]
        public ActionResult Logout()
        {
            if(SessionWrapper.UserName != null)
            {
                SessionWrapper.SignOut();
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
	}
}