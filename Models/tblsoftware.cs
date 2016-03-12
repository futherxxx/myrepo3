namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblsoftware")]
    public partial class tblsoftware
    {
        public int id { get; set; }
        [Display(Name = "Software Name ")]
        [StringLength(100)]
        public string name { get; set; }
        [Display(Name = "Serial Number ")]
        [StringLength(100)]
        public string serialno { get; set; }
        [Display(Name = "Software Version ")]
        [StringLength(100)]
        public string osversion { get; set; }

        [Display(Name = "office Version ")]
        [StringLength(100)]
        public string officeversion { get; set; }
    }
}
