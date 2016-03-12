namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbldept")]
    public partial class tbldept
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbldept()
        {
            tblstaff = new HashSet<tblstaff>();
        }

        public int id { get; set; }

        [Display(Name = "Department Name")]
        [StringLength(100)]
        public string name { get; set; }

        [Display(Name = "Select the Staff")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblstaff> tblstaff { get; set; }
    }
}
