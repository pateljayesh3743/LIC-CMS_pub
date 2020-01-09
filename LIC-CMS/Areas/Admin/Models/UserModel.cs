using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using LIC_CMS.Models;

namespace LIC_CMS.Areas.Admin.Models
{
    
    public class UserModel
    {
        [Display(Name="User Id")]
        public  int USER_ID { get; set; }

        [Display(Name = "User Name")]
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed")]
        public string USER_NAME { get; set; }

        [Display(Name = "Password")]
        [Required]
        [StringLength(32, MinimumLength = 8)]
        public string PASSWORD { get; set; }

        [Display(Name = "Confirm Password")]
        [Required]
        [StringLength(32, MinimumLength = 8)]
        public string CONFIRM_PASSWORD { get; set; }
        
        public DateTime CREATED_ON { get; set; }
        public int CREATED_BY { get; set; }
        public int UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public int IS_ACTIVE { get; set; }
        

        public static List<UserModel> getUserList()
        {
            List<UserModel> list = new List<UserModel>();
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                var query = db.USER_MASTER.OrderByDescending(x => x.USER_ID_).ToList();
                foreach(var item in query)
                {
                    list.Add(new UserModel {
                        USER_ID    =Convert.ToInt32(item.USER_ID_),
                        USER_NAME  =item.USER_NAME,
                        PASSWORD   =item.PASSWORD,
                        CREATED_ON =item.CREATED_ON,
                        IS_ACTIVE  =Convert.ToInt32(item.IS_ACTIVE),
                        UPDATED_BY=Convert.ToInt32(item.UPDATED_BY),
                        UPDATED_ON=Convert.ToDateTime(item.UPDATED_ON)
                    });
                }
                return list;
            }
        }

        public static UserModel getUserById(int ? id)
        {
            UserModel model = new UserModel();

                using(LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    var search = db.USER_MASTER.Where(x => x.USER_ID_ == id).FirstOrDefault();
                    if(search != null)
                    {
                        model.USER_ID = Convert.ToInt32(search.USER_ID_);
                        model.USER_NAME = search.USER_NAME;
                        model.PASSWORD = search.PASSWORD;

                        return model;
                    }
                    else
                    {
                        return new UserModel();
                    }
                }
        }

        public static bool insertUser(UserModel model)
        {
            string password = System.Web.Helpers.Crypto.HashPassword(model.PASSWORD);

            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                db.USER_MASTER.Add(new USER_MASTER { 
                        USER_NAME   = model.USER_NAME,
                        PASSWORD = password,
                        CREATED_ON  = DateTime.Now,
                        CREATED_BY  = Convert.ToInt32(HttpContext.Current.Session["UserId"].ToString()),
                        ROLE_ABBR   = "USR",
                        IS_ACTIVE   = 1
                });
                db.SaveChanges();
                return true;
            }
        }

        public static bool updateUser(UserModel model)
        {
            string password = System.Web.Helpers.Crypto.HashPassword(model.PASSWORD);
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                var search = db.USER_MASTER.Where(x => x.USER_ID_ == model.USER_ID).FirstOrDefault();
                search.USER_NAME = model.USER_NAME;
                search.PASSWORD = password;
                search.UPDATED_BY = Convert.ToInt32(HttpContext.Current.Session["UserId"].ToString());
                search.UPDATED_ON = DateTime.Now;
                db.SaveChanges();
                return true;
            }
        }
    }
}