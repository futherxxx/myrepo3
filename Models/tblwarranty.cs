namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblwarranty")]
    public partial class tblwarranty
    {
        public int id { get; set; }
        [Display(Name = "System Name")]
        public int? fksystem { get; set; }
        [Display(Name = "Assigned To Who?")]
        [StringLength(50)]
        public string assignedto { get; set; }
        [Display(Name = "Date Configured")]
        [Column(TypeName = "date")]
        public DateTime? configdate { get; set; }
        [Display(Name = "Prepared By")]
        [StringLength(50)]
        public string preparedby { get; set; }
        [Display(Name = "Purchase Date")]
        [Column(TypeName = "date")]
        public DateTime? dateofpurchase { get; set; }

        public int? warrantystatus { get; set; }

        public int? warrantyexpiration { get; set; }

        public int? fkvendor { get; set; }

        public virtual tblstatus tblstatus { get; set; }

        public virtual tblsystem tblsystem { get; set; }

        public virtual tblvendor tblvendor { get; set; }
    }
}
