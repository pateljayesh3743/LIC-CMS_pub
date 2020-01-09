using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
    

namespace LIC_CMS.Models
{
    public class UserDetailModel 
    {
        [Display(Name="User Detail Id")]
        public int USER_DETAIL_ID { get; set; }

        [Display(Name="First Name :")]
        [Required]
        public string FIRST_NAME { get; set; }

        [Display(Name="Lats Name :")]
        [Required]
        public string LAST_NAME { get; set; }

        [Display(Name="Middle Name :")]
        [Required]
        public string MIDDLE_NAME { get; set; }

        [Display(Name="Mobile :")]
        [Required]
        public string MOBILE { get; set; }

        [Display(Name="Email :")]

        [Required]
        [EmailAddress]
        public string EMAIL { get; set; }

        [Display(Name="Address :")]
        public string ADDRESS { get; set; }
        [Display(Name="Pin Code :")]
        public string PIN_CODE { get; set; }
        [Display(Name="Agent Code :")]
        [Required]
        public string AGENT_CODE { get; set; }
        [Display(Name="User Id")]
        public int USER_ID { get; set; }
        [Display(Name="Country Name :")]
        public int COUNTRY_ID { get; set; }
        [Display(Name = "State Name :")]
        public int STATE_ID { get; set; }
        [Display(Name="City Name :")]
        [Required(ErrorMessage="The City Name field is required.")]
        public int CITY_ID { get; set; }

        public static bool insertUserDetail(UserDetailModel model)
        {
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                db.USER_DETAIL_MASTER.Add(new USER_DETAIL_MASTER{
                    FIRST_NAME=model.FIRST_NAME,
                    MIDDLE_NAME=model.MIDDLE_NAME,
                    LAST_NAME=model.LAST_NAME,
                    PIN_CODE=model.PIN_CODE,
                    AGENT_CODE=model.AGENT_CODE,
                    CITY_ID=model.CITY_ID,
                    ADDRESS=model.ADDRESS,
                    EMAIL=model.EMAIL,
                    MOBILE=model.MOBILE,
                });
                db.SaveChanges();
                return true;
            }
        }
    }
}