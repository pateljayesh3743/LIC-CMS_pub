//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LIC_CMS.Models
{
    using System;
    
    public partial class spGetClientAssuranceMaster_Result
    {
        public int CLIENTASSURANCE_ID { get; set; }
        public Nullable<double> PREMIUM { get; set; }
        public string POLICY_NUMBER { get; set; }
        public Nullable<double> SUM_OF_ASSURANCE { get; set; }
        public Nullable<int> PLAN_ID { get; set; }
        public Nullable<int> MODE_ID { get; set; }
        public Nullable<int> TERM_ID { get; set; }
        public Nullable<System.DateTime> DATE_OF_MATURITY { get; set; }
        public Nullable<System.DateTime> NEXT_PREMIUM_DATE { get; set; }
        public string NOMINEE { get; set; }
        public Nullable<int> CLIENT_ID { get; set; }
        public Nullable<bool> IS_ACTIVE { get; set; }
        public Nullable<bool> IS_DELETE { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_ON { get; set; }
    }
}
