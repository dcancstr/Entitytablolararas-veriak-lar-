//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_musteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_musteri()
        {
            this.tbl_satis = new HashSet<tbl_satis>();
        }
    
        public int musteriid { get; set; }
        public string musteriadsoyad { get; set; }
        public string telno { get; set; }
        public string tc { get; set; }
        public string adres { get; set; }
        public string meslek { get; set; }
        public string sehir { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_satis> tbl_satis { get; set; }
    }
}