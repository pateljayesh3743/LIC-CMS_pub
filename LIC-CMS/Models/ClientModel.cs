using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LIC_CMS.Models
{
    public class ClientModel
    {
        [Display(Name="Client Id")]
        public int CLIENT_ID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FIRST_NAME { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LAST_NAME { get; set; }

        [Display(Name = "Middle Name")]
        [Required]
        public string MIDDLE_NAME { get; set; }

        [Display(Name = "DOB")]
        [Required]
        public DateTime DOB { get; set; }

        [Display(Name = "Age")]
        [Required]
        public int AGE { get; set; }

        [Display(Name = "Mobile")]
        public string MOBILE { get; set; }

        [Display(Name = "Email")]
        public string EMAIL { get; set; }

        [Display(Name = "DOS")]
        [Required]
        public DateTime DOS { get; set; }

        [Display(Name = "Weight")]
        public Double WEIGHT { get; set; }

        [Display(Name = "Height")]
        public Double HEIGHT { get; set; }

        [Display(Name = "Identity of Body")]
        [Required]
        public string IDENTITY_OF_BODY { get; set; }

        [Display(Name = "Address")]
        public string AADDRESS { get; set; }

        [Display(Name = "Pin Code")]
        [Required]
        public string PIN_CODE { get; set; }

        [Display(Name = "Country Id")]
        [Required]
        public int COUNTRY_ID { get; set; }

        [Display(Name = "State Id")]
        [Required]
        public int STATE_ID { get; set; }

        [Display(Name = "City Id")]
        [Required]
        public int CITY_ID { get; set; }

        [Display(Name = "User Id")]
        public int USER_ID { get; set; }
    }
}