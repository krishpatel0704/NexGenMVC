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
    
    public partial class tblClient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblClient()
        {
            this.tblInterventions = new HashSet<tblIntervention>();
        }
    
        public string clientId { get; set; }
        public string clientName { get; set; }
        public string clientDistrict { get; set; }
        public string clientDesLocation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblIntervention> tblInterventions { get; set; }
    }
}