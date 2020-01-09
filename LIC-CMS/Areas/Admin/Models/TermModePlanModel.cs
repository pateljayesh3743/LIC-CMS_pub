using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using LIC_CMS.Models;

namespace LIC_CMS.Areas.Admin.Models
{
    public class GenralProperties
    {
        public int IS_ACTIVE { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }

    }
    #region Plan
    public class PlanModel :GenralProperties
    {
        [Display(Name = "Plan Id")]
        public int PLAN_ID { get; set; }

        [Display(Name = "Plan Name")]
        [Required]
        public string PLAN_NAME { get; set; }

        [Display(Name = "Plan Code")]
        [Required]
        public string PLAN_CODE { get; set; }

        public static List<PlanModel> getAllPlan()
        {
            List<PlanModel> list = new List<PlanModel>();
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                foreach(var item in db.PLAN_MASTER.ToList())
                {
                    list.Add(new PlanModel { 
                        PLAN_ID=item.PLAN_ID,
                        PLAN_CODE=item.PLAN_CODE,
                        PLAN_NAME=item.PLAN_NAME,
                        IS_ACTIVE=Convert.ToInt32(item.IS_ACTIVE),
                        UPDATED_BY=Convert.ToInt32(item.UPDATED_BY),
                        UPDATED_ON=Convert.ToDateTime(item.UPDATED_ON),
                        CREATED_BY=Convert.ToInt32(item.CREATED_BY),
                        CREATED_ON=Convert.ToDateTime(item.CREATED_ON)
                    });
                }
                return list;
            }
        }
        public static bool insertPlan(PlanModel model)
        {
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                db.PLAN_MASTER.Add(new PLAN_MASTER {
                    
                    PLAN_CODE=model.PLAN_CODE,
                    PLAN_NAME=model.PLAN_NAME,
                    IS_ACTIVE = 1,
                    CREATED_BY=SessionWrapper.UserId,
                    CREATED_ON=DateTime.Now
                });
                db.SaveChanges();
                return true;
            }
        }
        public static PlanModel getPlanById(int ? id)
        {
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                var query = db.PLAN_MASTER.Where(x => x.PLAN_ID == id).FirstOrDefault();
                return new PlanModel { 
                    PLAN_ID=query.PLAN_ID,
                    PLAN_CODE=query.PLAN_CODE,
                    PLAN_NAME=query.PLAN_NAME
                };
            }
        }
        public static bool updatePlan(PlanModel model)
        {
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                var query = db.PLAN_MASTER.Where(x => x.PLAN_ID == model.PLAN_ID).FirstOrDefault();
                query.PLAN_CODE = model.PLAN_CODE;
                query.PLAN_NAME = model.PLAN_NAME;
                query.UPDATED_BY = SessionWrapper.UserId;
                query.UPDATED_ON = DateTime.Now;

                db.SaveChanges();
                return true;
            }
        }
    }

    #endregion

    #region Term
    public class TermModel:GenralProperties
    {
        [Display(Name = "Term Id")]
        public int TERM_ID { get; set; }

        [Display(Name = "Term Name")]
        [Required]
        public string TERM_NAME { get; set; }

         public static List<TermModel> getAllTerm()
        {
            List<TermModel> list = new List<TermModel>();
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                foreach(var item in db.TERM_MASTER.ToList())
                {
                    list.Add(new TermModel { 
                        TERM_ID=item.TERM_ID,
                        TERM_NAME=item.TERM_NAME,
                        IS_ACTIVE=Convert.ToInt32(item.IS_ACTIVE),
                        UPDATED_BY=Convert.ToInt32(item.UPDATED_BY),
                        UPDATED_ON=Convert.ToDateTime(item.UPDATED_ON),
                        CREATED_BY=Convert.ToInt32(item.CREATED_BY),
                        CREATED_ON=Convert.ToDateTime(item.CREATED_ON)
                    });
                }
                return list;
            }
        }
        public static bool insertTerm(TermModel model)
        {
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                db.TERM_MASTER.Add(new TERM_MASTER {
                    
                    
                    TERM_NAME=model.TERM_NAME,
                    IS_ACTIVE = 1,
                    CREATED_BY=SessionWrapper.UserId,
                    CREATED_ON=DateTime.Now
                });
                db.SaveChanges();
                return true;
            }
        }
        public static TermModel getTermById(int ? id)
        {
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                var query = db.TERM_MASTER.Where(x => x.TERM_ID == id).FirstOrDefault();
                return new  TermModel{ 
                    TERM_ID=query.TERM_ID,
                    TERM_NAME=query.TERM_NAME
                };
            }
        }
        public static bool updateTerm(TermModel model)
        {
            using(LIC_CMSEntities db=new LIC_CMSEntities())
            {
                var query = db.TERM_MASTER.Where(x =>x.TERM_ID == model.TERM_ID).FirstOrDefault();
                query.TERM_NAME = model.TERM_NAME;
                query.UPDATED_BY = SessionWrapper.UserId;
                query.UPDATED_ON = DateTime.Now;

                db.SaveChanges();
                return true;
            }
        }
    }
    

    #endregion

    #region Mode
    public class ModeModel:GenralProperties
    {
        [Display(Name = "Mode Id")]
        public int MODE_ID { get; set; }

        [Display(Name = "Mode Name")]
        [Required]
        public string MODE_NAME { get; set; }

        public static List<ModeModel> getAllMode()
        {
            List<ModeModel> list = new List<ModeModel>();
            using (LIC_CMSEntities db = new LIC_CMSEntities())
            {
                foreach (var item in db.MODE_MASTER.ToList())
                {
                    list.Add(new ModeModel
                    {
                        MODE_ID= item.MODE_ID,
                        MODE_NAME = item.MODE_NAME,
                        IS_ACTIVE = Convert.ToInt32(item.IS_ACTIVE),
                        UPDATED_BY = Convert.ToInt32(item.UPDATED_BY),
                        UPDATED_ON = Convert.ToDateTime(item.UPDATED_ON),
                        CREATED_BY = Convert.ToInt32(item.CREATED_BY),
                        CREATED_ON = Convert.ToDateTime(item.CREATED_ON)
                    });
                }
                return list;
            }
        }
        public static bool insertMode(ModeModel model)
        {
            using (LIC_CMSEntities db = new LIC_CMSEntities())
            {
                db.MODE_MASTER.Add(new MODE_MASTER
                {
                    MODE_NAME = model.MODE_NAME,
                    IS_ACTIVE = 1,
                    CREATED_BY = SessionWrapper.UserId,
                    CREATED_ON = DateTime.Now
                });
                db.SaveChanges();
                return true;
            }
        }
        public static ModeModel getModeById(int? id)
        {
            using (LIC_CMSEntities db = new LIC_CMSEntities())
            {
                var query = db.MODE_MASTER.Where(x => x.MODE_ID == id).FirstOrDefault();
                return new ModeModel
                {
                    MODE_ID = query.MODE_ID,
                    MODE_NAME = query.MODE_NAME
                };
            }
        }
        public static bool updateMode(ModeModel model)
        {
            using (LIC_CMSEntities db = new LIC_CMSEntities())
            {
                var query = db.MODE_MASTER.Where(x => x.MODE_ID == model.MODE_ID).FirstOrDefault();
                query.MODE_NAME = model.MODE_NAME;
                query.UPDATED_BY = SessionWrapper.UserId;
                query.UPDATED_ON = DateTime.Now;

                db.SaveChanges();
                return true;
            }
        }
    }
    #endregion
}