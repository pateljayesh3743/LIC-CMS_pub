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
    using System.Collections.Generic;
    
    public partial class USER_MASTER
    {
        public USER_MASTER()
        {
            this.CLIENT_MASTER = new HashSet<CLIENT_MASTER>();
            this.USER_DETAIL_MASTER = new HashSet<USER_DETAIL_MASTER>();
        }
    
        public long USER_ID_ { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public System.DateTime CREATED_ON { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public string ROLE_ABBR { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<int> IS_ACTIVE { get; set; }
        public Nullable<System.DateTime> UPDATED_ON { get; set; }
    
        public virtual ICollection<CLIENT_MASTER> CLIENT_MASTER { get; set; }
        public virtual ICollection<USER_DETAIL_MASTER> USER_DETAIL_MASTER { get; set; }
    }
}
