namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblsystem")]
    public partial class tblsystem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblsystem()
        {
            tbldesktop = new HashSet<tbldesktop>();
            tbllaptop = new HashSet<tbllaptop>();
            tblnetwork = new HashSet<tblnetwork>();
            tblsystem1 = new HashSet<tblsystem>();
            tblwarranty = new HashSet<tblwarranty>();
        }

        public int id { get; set; }
        [Display(Name = "System Name")]
        [StringLength(100)]
        public string name { get; set; }
        [Display(Name = "System Model")]
        [StringLength(100)]
        public string model { get; set; }
        [Display(Name = "Serial Number")]
        [StringLength(100)]
        public string serialno { get; set; }
         [Display(Name = "Part Number")]
        [StringLength(100)]
        public string pno { get; set; }
        [Display(Name = "Processor Type")]
        [StringLength(100)]
        public string processor { get; set; }
        [Display(Name = "Memory Type")]
        [StringLength(100)]
        public string memory { get; set; }
        [Display(Name = "Hard Disk Size")]
        [StringLength(100)]
        public string hdd { get; set; }
        [Display(Name = "DVD Model")]
        [StringLength(100)]
        public string dvdcd { get; set; }
        
        [Display(Name = "System Status")]
        [StringLength(100)]
        public string operational { get; set; }

        public int? fkvendor { get; set; }

        public int? fksystemtype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbldesktop> tbldesktop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbllaptop> tbllaptop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblnetwork> tblnetwork { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblsystem> tblsystem1 { get; set; }

        public virtual tblsystem tblsystem2 { get; set; }

        public virtual tblvendor tblvendor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblwarranty> tblwarranty { get; set; }
    }
}
