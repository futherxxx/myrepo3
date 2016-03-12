namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblbattery")]
    public partial class tblbattery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblbattery()
        {
            tbllaptop = new HashSet<tbllaptop>();
        }

        public int id { get; set; }

        [Display(Name = "Battery Name")]
        [StringLength(100)]
        public string name { get; set; }
        
        [Display(Name="Serial Number")]
        [StringLength(100)]
        public string serialno { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [StringLength(100)]
        public string txtdesc { get; set; }

        [Display(Name = "Select the vendor ")]
        public int? fkvendor { get; set; }

        [Display(Name = "Select the vendor ")]
        public virtual tblvendor tblvendor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbllaptop> tbllaptop { get; set; }
    }
}
