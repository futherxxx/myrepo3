namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblstatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblstatus()
        {
            tblwarranty = new HashSet<tblwarranty>();
        }

        public int id { get; set; }
        [Display(Name = "Status Name")]
       
        [StringLength(100)]
        public string name { get; set; }
        [Display(Name = "Status Description ")]
        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblwarranty> tblwarranty { get; set; }
    }
}
