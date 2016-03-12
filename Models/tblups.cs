namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblups
    {
        public int id { get; set; }
        [Display(Name = "UPS Name")]
        [StringLength(100)]
        public string name { get; set; }
        [Display(Name = "Serial Number")]
        [StringLength(100)]
        public string serialno { get; set; }
        [Display(Name = "System Version")]
        [StringLength(100)]
        public string version { get; set; }
        [Display(Name = "Select Vendor")]
        public int? fkvendor { get; set; }

        public virtual tblvendor tblvendor { get; set; }
    }
}
