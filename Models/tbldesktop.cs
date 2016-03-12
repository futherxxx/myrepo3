namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbldesktop")]
    public partial class tbldesktop
    {
        public int id { get; set; }
        [Display(Name = "Official Name")]
        [StringLength(100)]
        public string name { get; set; }

        [Display(Name = "Select the vendor ")]
        public int? fksystem { get; set; }

        [Display(Name = "Select the vendor ")]
        public int? fkmonitor { get; set; }

        [Display(Name = "Select the keboard")]
        public int? fkkeyboard { get; set; }

         [Display(Name = "Select the Mouse ")]
        public int? fkmouse { get; set; }
        [Display(Name = "Select the power pack ")]
        public int? fkpowerpack { get; set; }

        public virtual tblkeyboard tblkeyboard { get; set; }

        public virtual tblmonitor tblmonitor { get; set; }

        public virtual tblmouse tblmouse { get; set; }

        public virtual tblpowerpack tblpowerpack { get; set; }

        public virtual tblsystem tblsystem { get; set; }
    }
}
