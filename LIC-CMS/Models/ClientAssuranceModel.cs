using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LIC_CMS.Models
{
    public class ClientAssuranceModel:ClientModel
    {
        [Display(Name="Client Assurance Id")]
        public int CLIENTASSURANCE_ID { get; set; }

        [Display(Name = "Premium")]
        [Required]
        public float PREMIUM { get; set; }

        [Display(Name = "Policy Number")]
        [Required]
        public string POLICY_NUMBER { get; set; }

        [Display(Name = "Sum of Assurance")]
        [Required]
        public float SUM_OF_ASSURANCE { get; set; }

        [Display(Name = "Plan Id")]
        [Required]
        public int PLAN_ID { get; set; }

        [Display(Name = "Mode Id")]
        [Required]
        public int MODE_ID { get; set; }

        [Display(Name = "Term Id")]
        [Required]
        public int TERM_ID { get; set; }

        [Display(Name = "Date of Maturity")]
        [Required]
        public DateTime DATE_OF_MATURITY { get; set; }

        [Display(Name = "Next Premium Date")]
        [Required]
        public DateTime NEXT_PREMIUM_DATE { get; set; }

        [Display(Name = "Nominee")]
        public string NOMINEE { get; set; }

        public static List<SelectListItem> FillPlanDropDown()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (LIC_CMSEntities db = new LIC_CMSEntities())
            { 
                foreach(var item in db.PLAN_MASTER.ToList())
                {
                    list.Add(new SelectListItem { 
                        Text=item.PLAN_NAME,
                        Value=item.PLAN_ID.ToString()
                    });
                }
            }
            return list;
        }

        public static List<SelectListItem> FillModeDropDown()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (LIC_CMSEntities db = new LIC_CMSEntities())
            {
                foreach (var item in db.MODE_MASTER.ToList())
                {
                    list.Add(new SelectListItem
                    {
                        Text = item.MODE_NAME,
                        Value = item.MODE_ID.ToString()
                    });
                }
            }
            return list;
        }

        public static List<SelectListItem> FillTermDropDown()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using (LIC_CMSEntities db = new LIC_CMSEntities())
            {
                foreach (var item in db.TERM_MASTER.ToList())
                {
                    list.Add(new SelectListItem
                    {
                        Text = item.TERM_NAME,
                        Value = item.TERM_ID.ToString()
                    });
                }
            }
            return list;
        }

        //public static List<ClientAssuranceModel> GetClient()
        //{
        //    List<ClientAssuranceModel> list = new List<ClientAssuranceModel>();
        //    using(LIC_CMSEntities db=new LIC_CMSEntities())
        //    {
        //        foreach(var item in db.spGetClientMaster().ToList())
        //        {
        //            list.Add(new ClientAssuranceModel { 
                           
        //                FIRST_NAME=item.FIRST_NAME,
        //                MIDDLE_NAME=item.MIDDLE_NAME,
        //                LAST_NAME=item.LAST_NAME,
        //                DOS=item.DOS,
        //                POLICY_NUMBER=item.
        //    //             <th>Client Name</th>
        //    //<th>DOS</th>
        //    //<th>Policy Number</th>
        //    //<th>Next Premium Date</th>
        //    //<th>Sum Of Assurance</th>
        //    //<th>Plan</th>
        //    //<th>Mode</th>
        //            });
        //        }
        //    }
        //}
    }
}