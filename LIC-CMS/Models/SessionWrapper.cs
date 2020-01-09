using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIC_CMS.Models
{
    public class SessionWrapper
    {
        public static string RoleName
        {
            get
            {
                if (HttpContext.Current.Session["RoleName"] != null)
                    return HttpContext.Current.Session["RoleName"] as string;
                return "";
            }
            set
            {
                HttpContext.Current.Session["RoleName"] = value;
            }
        }

        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] != null)
                    return HttpContext.Current.Session["UserName"].ToString();
                return "";
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }

        public static int UserId
        {
            get
            {
                if (HttpContext.Current.Session["UserId"] != null)
                    return int.Parse(HttpContext.Current.Session["UserId"].ToString());
                return 0;
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static void SignOut()
        {
            HttpContext.Current.Session.Abandon();
        }
            
    }
}