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
    
    public partial class TERM_MASTER
    {
        public TERM_MASTER()
        {
            this.CLIENTASSURANCE_MASTER = new HashSet<CLIENTASSURANCE_MASTER>();
        }
    
        public int TERM_ID { get; set; }
        public string TERM_NAME { get; set; }
        public Nullable<int> IS_ACTIVE { get; set; }
        public Nullable<System.DateTime> UPDATED_ON { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
    
        public virtual ICollection<CLIENTASSURANCE_MASTER> CLIENTASSURANCE_MASTER { get; set; }
    }
}
