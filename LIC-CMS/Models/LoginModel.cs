 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LIC_CMS.Models
{
    public class LoginModel
    {
        [Display(Name="Enter User Name ")]
        [Required]
        public string USER_NAME { get; set; }

        [Display(Name="Enter Password ")]
        [Required]
        public string PASSWORD { get; set; }
    }
}