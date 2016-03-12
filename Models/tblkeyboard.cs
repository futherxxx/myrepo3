namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblkeyboard")]
    public partial class tblkeyboard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblkeyboard()
        {
            tbldesktop = new HashSet<tbldesktop>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }
        [Display(Name = "Serial Number")]
        [StringLength(100)]
        public string serialno { get; set; }
        [Display(Name = "Keyboard Type")]
        [StringLength(100)]
        public string version { get; set; }
        [Display(Name = "Vendor Name")]
        public int? fkvendor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbldesktop> tbldesktop { get; set; }

        public virtual tblvendor tblvendor { get; set; }
    }
}
