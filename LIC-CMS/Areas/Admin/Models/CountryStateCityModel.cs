using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using LIC_CMS.Models;


namespace LIC_CMS.Areas.Admin.Models
{
 
    #region CountryViewModel
        public class CountryModel
        {
            [Display(Name = "Country Id")]
            public int COUNTRY_ID { get; set; }
            [Display(Name = "Country Name")]
            [Required]
            public string COUNTRY_NAME { get; set; }

            public static List<CountryModel> getCountry()
            {
                List<CountryModel> list = new List<CountryModel>();

                using(LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    foreach(var item in db.COUNTRY_MASTER.ToList())
                    {
                        list.Add(new CountryModel { 
                            COUNTRY_ID=item.COUNTRY_ID,
                            COUNTRY_NAME=item.COUNTRY_NAME
                        });
                    }
                    return list;
                }
            }
            public static bool insertCountry(CountryModel model)
            {
                using (LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    db.COUNTRY_MASTER.Add(new COUNTRY_MASTER
                    {
                        COUNTRY_NAME = model.COUNTRY_NAME
                    });
                    int valid = db.SaveChanges();
                    if(valid == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            public static CountryModel getCountryById(int ? id)
            {
                using(LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    var query=db.COUNTRY_MASTER.Where(x=>x.COUNTRY_ID==id).FirstOrDefault();
                    return new CountryModel
                    {
                        COUNTRY_ID = query.COUNTRY_ID,
                        COUNTRY_NAME = query.COUNTRY_NAME
                    };
                }
            }

            public static bool updateCountry(CountryModel model)
            {
                using(LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    var query = db.COUNTRY_MASTER.Where(x => x.COUNTRY_ID == model.COUNTRY_ID).FirstOrDefault();
                    query.COUNTRY_NAME = model.COUNTRY_NAME;
                    int valid = db.SaveChanges();
                    if (valid == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        #endregion

        #region State
        public class StateModel
        {

            [Display(Name = "State Id")]
            public int STATE_ID { get; set; }
            [Display(Name = "State Name")]
            [Required]
            public string STATE_NAME { get; set; }
            [Display(Name = "Country Name")]
            [Required]
            public int COUNTRY_ID { get; set; }

            public static List<SelectListItem> countrylist()
            {
                List<SelectListItem> list = new List<SelectListItem>();

                using (LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    foreach (var item in db.COUNTRY_MASTER.ToList())
                    {
                        list.Add(new SelectListItem
                        {
                            Text = item.COUNTRY_NAME,
                            Value = item.COUNTRY_ID.ToString()
                        });
                    }
                    return list;
                }
            }

            public static string getCountryNameById(int id)
            {
                if (id != null && id != 0)
                {
                   using(LIC_CMSEntities db=new LIC_CMSEntities())
                   {
                       var query = db.STATE_MASTER.Where(x => x.STATE_ID== id).FirstOrDefault();
                       var result = db.COUNTRY_MASTER.Where(x => x.COUNTRY_ID== query.COUNTRY_ID).FirstOrDefault();
                       return result.COUNTRY_NAME;
                   }
                }
                else
                {
                    return "";
                }
            }
            public static List<StateModel> getState()
            {
                List<StateModel> list = new List<StateModel>();

                using (LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    foreach (var item in db.STATE_MASTER.ToList())
                    {
                        list.Add(new StateModel
                        {
                            STATE_ID = item.STATE_ID,
                            STATE_NAME = item.STATE_NAME,
                            COUNTRY_ID=Convert.ToInt32(item.COUNTRY_ID)
                        });
                    }
                    return list;
                }
            }
            public static bool insertState(StateModel model)
            {
                using (LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    db.STATE_MASTER.Add(new STATE_MASTER
                    {
                        STATE_NAME = model.STATE_NAME,
                        COUNTRY_ID = model.COUNTRY_ID
                    });
                    int valid = db.SaveChanges();
                    if (valid == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public static StateModel getStateById(int ? id)
            {
                using(LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    var query=db.STATE_MASTER.Where(x=>x.STATE_ID==id).FirstOrDefault();
                    return new StateModel
                    {
                        STATE_ID   = query.STATE_ID,
                        STATE_NAME = query.STATE_NAME,
                        COUNTRY_ID = Convert.ToInt32(query.COUNTRY_ID)
                    };
                }
            }

            public static bool updateState(StateModel model)
            {
                using(LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    var query = db.STATE_MASTER.Where(x => x.STATE_ID == model.STATE_ID).FirstOrDefault();
                    query.STATE_NAME = model.STATE_NAME;
                    query.COUNTRY_ID = model.COUNTRY_ID;
                    int valid = db.SaveChanges();
                    if (valid == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        #endregion

        #region City
        public class CityModel
        {
            [Display(Name = "City Id")]
            public int CITY_ID { get; set; }
            [Display(Name = "City Name")]
            [Required]
            public string CITY_NAME { get; set; }
            [Display(Name = "State Name")]
            [Required]
            public int STATE_ID { get; set; }
            [Display(Name = "Country Name")]
            [Required]
            public int COUNTRY_ID { get; set; }

            public static List<SelectListItem> listState()
            {
                List<SelectListItem> list = new List<SelectListItem>();
                using (LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    foreach (var item in db.STATE_MASTER.ToList())
                    {
                        list.Add(new SelectListItem
                        {

                            Text = item.STATE_NAME,
                            Value = item.STATE_ID.ToString()
                        });
                    }
                    return list;
                }
            }
            public static List<CityModel> getCity()
            {
                List<CityModel> list = new List<CityModel>();

                using (LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    foreach (var item in db.CITY_MASTER.ToList())
                    {
                        list.Add(new CityModel
                        {
                            CITY_ID = item.CITY_ID,
                            CITY_NAME = item.CITY_NAME,
                            STATE_ID = Convert.ToInt32(item.STATE_ID)
                        });
                    }
                    return list;
                }
            }
            public static bool insertCity(CityModel model)
            {
                using (LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    db.CITY_MASTER.Add(new CITY_MASTER
                    {

                        CITY_NAME = model.CITY_NAME,
                        STATE_ID = model.STATE_ID

                    });
                    int valid = db.SaveChanges();
                    if (valid == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            public static string getStateNameById(int id)
            {
                if (id != null && id != 0)
                {
                    using (LIC_CMSEntities db=new LIC_CMSEntities())
                    {
                        var result = db.STATE_MASTER.Where(x => x.STATE_ID == id).FirstOrDefault();
                        return result.STATE_NAME;
                    }
                }
                else
                {
                    return "";
                }
            }

            public static CityModel getCityById(int ? id)
            {
                using(LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    var query = db.CITY_MASTER.Where(x => x.CITY_ID == id).FirstOrDefault();
                    var country = db.STATE_MASTER.Where(x => x.STATE_ID == query.STATE_ID).FirstOrDefault();
                    return new CityModel
                    {
                        CITY_ID=query.CITY_ID,
                        CITY_NAME=query.CITY_NAME,
                        STATE_ID=Convert.ToInt32(query.STATE_ID),
                        COUNTRY_ID=Convert.ToInt32(country.COUNTRY_ID)
                    };
                }
            }

            public static bool updateCity(CityModel model)
            {
                using(LIC_CMSEntities db=new LIC_CMSEntities())
                {
                    var query = db.CITY_MASTER.Where(x => x.CITY_ID == model.CITY_ID).FirstOrDefault();
                    query.CITY_NAME = model.CITY_NAME;
                    query.STATE_ID = model.STATE_ID;
                    int valid = db.SaveChanges();
                    if (valid == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        #endregion
}