//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NexGenMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUser()
        {
            this.tblAuditInterventions = new HashSet<tblAuditIntervention>();
            this.tblInterventions = new HashSet<tblIntervention>();
        }
    
        public string userId { get; set; }
        public string userName { get; set; }
        public string userDistrict { get; set; }
        public Nullable<int> userHourAllowed { get; set; }
        public Nullable<double> userCostAllowed { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAuditIntervention> tblAuditInterventions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblIntervention> tblInterventions { get; set; }
    }
}