namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblpowerpack")]
    public partial class tblpowerpack
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblpowerpack()
        {
            tbldesktop = new HashSet<tbldesktop>();
        }

        public int id { get; set; }

        [Display(Name = "Powerpack Name ")]
        [StringLength(100)]
        public string name { get; set; }

        [Display(Name = "Serial Number ")]
        [StringLength(100)]
        public string serialno { get; set; }
        
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [StringLength(100)]
        public string txtdesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbldesktop> tbldesktop { get; set; }
    }
}
