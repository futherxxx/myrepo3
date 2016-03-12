namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbllaptop")]
    public partial class tbllaptop
    {
        public int id { get; set; }
        [Display(Name = "Select Battery ")]
        public int? fkbattery { get; set; }

        [Display(Name = "Select the System")]
        public int? fksystem { get; set; }

        public virtual tblbattery tblbattery { get; set; }

        public virtual tblsystem tblsystem { get; set; }
    }
}
