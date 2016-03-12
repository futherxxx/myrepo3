namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblstaff")]
    public partial class tblstaff
    {
        public int id { get; set; }
        [Display(Name = "Staff Name")]
        [StringLength(100)]
        public string name { get; set; }
         [Display(Name = "Staff Department ")]
        public int? fkdept { get; set; }

        public virtual tbldept tbldept { get; set; }
    }
}
