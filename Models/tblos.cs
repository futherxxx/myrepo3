namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblos
    {
        public int id { get; set; }
        [Display(Name = "Name of Setup ")]
        [StringLength(100)]
        public string name { get; set; }
        [Display(Name = "Software Version ")]
        [StringLength(100)]
        public string version { get; set; }
        [Display(Name = "Supplied by ")]
        public int? fkvendor { get; set; }

        public virtual tblvendor tblvendor { get; set; }
    }
}
