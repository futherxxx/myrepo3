namespace PCDetailsWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblnetwork")]
    public partial class tblnetwork
    {    
        public int id { get; set; }
        [Display(Name = "Select the system")]
        public int? fksystem { get; set; }
        [Display(Name = "mac Address ")]
        [StringLength(100)]
        public string macaddress { get; set; }

        public virtual tblsystem tblsystem { get; set; }
    }
}
