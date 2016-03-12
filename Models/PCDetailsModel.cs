namespace PCDetailsWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PCDetailsModel : DbContext
    {
        public PCDetailsModel()
            : base("name=PCDetailsModel")
        {
        }

        public virtual DbSet<tblbattery> tblbattery { get; set; }
        public virtual DbSet<tbldept> tbldept { get; set; }
        public virtual DbSet<tbldesktop> tbldesktop { get; set; }
        public virtual DbSet<tblkeyboard> tblkeyboard { get; set; }
        public virtual DbSet<tbllaptop> tbllaptop { get; set; }
        public virtual DbSet<tblmonitor> tblmonitor { get; set; }
        public virtual DbSet<tblmouse> tblmouse { get; set; }
        public virtual DbSet<tblnetwork> tblnetwork { get; set; }
        public virtual DbSet<tbloffice> tbloffice { get; set; }
        public virtual DbSet<tblos> tblos { get; set; }
        public virtual DbSet<tblpowerpack> tblpowerpack { get; set; }
        public virtual DbSet<tblsoftware> tblsoftware { get; set; }
        public virtual DbSet<tblstaff> tblstaff { get; set; }
        public virtual DbSet<tblstatus> tblstatus { get; set; }
        public virtual DbSet<tblsystem> tblsystem { get; set; }
        public virtual DbSet<tblups> tblups { get; set; }
        public virtual DbSet<tblvendor> tblvendor { get; set; }
        public virtual DbSet<tblwarranty> tblwarranty { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblbattery>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblbattery>()
                .Property(e => e.serialno)
                .IsUnicode(false);

            modelBuilder.Entity<tblbattery>()
                .Property(e => e.txtdesc)
                .IsUnicode(false);

            modelBuilder.Entity<tblbattery>()
                .HasMany(e => e.tbllaptop)
                .WithOptional(e => e.tblbattery)
                .HasForeignKey(e => e.fkbattery);

            modelBuilder.Entity<tbldept>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tbldept>()
                .HasMany(e => e.tblstaff)
                .WithOptional(e => e.tbldept)
                .HasForeignKey(e => e.fkdept);

            modelBuilder.Entity<tbldesktop>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblkeyboard>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblkeyboard>()
                .Property(e => e.serialno)
                .IsUnicode(false);

            modelBuilder.Entity<tblkeyboard>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<tblkeyboard>()
                .HasMany(e => e.tbldesktop)
                .WithOptional(e => e.tblkeyboard)
                .HasForeignKey(e => e.fkkeyboard);

            modelBuilder.Entity<tblmonitor>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblmonitor>()
                .Property(e => e.serialno)
                .IsUnicode(false);

            modelBuilder.Entity<tblmonitor>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<tblmonitor>()
                .HasMany(e => e.tbldesktop)
                .WithOptional(e => e.tblmonitor)
                .HasForeignKey(e => e.fkmonitor);

            modelBuilder.Entity<tblmouse>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblmouse>()
                .Property(e => e.serialno)
                .IsUnicode(false);

            modelBuilder.Entity<tblmouse>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<tblmouse>()
                .HasMany(e => e.tbldesktop)
                .WithOptional(e => e.tblmouse)
                .HasForeignKey(e => e.fkmouse);

            modelBuilder.Entity<tblnetwork>()
                .Property(e => e.macaddress)
                .IsUnicode(false);

            modelBuilder.Entity<tbloffice>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tbloffice>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<tblos>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblos>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<tblpowerpack>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblpowerpack>()
                .Property(e => e.serialno)
                .IsUnicode(false);

            modelBuilder.Entity<tblpowerpack>()
                .Property(e => e.txtdesc)
                .IsUnicode(false);

            modelBuilder.Entity<tblpowerpack>()
                .HasMany(e => e.tbldesktop)
                .WithOptional(e => e.tblpowerpack)
                .HasForeignKey(e => e.fkpowerpack);

            modelBuilder.Entity<tblsoftware>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblsoftware>()
                .Property(e => e.serialno)
                .IsUnicode(false);

            modelBuilder.Entity<tblsoftware>()
                .Property(e => e.osversion)
                .IsUnicode(false);

            modelBuilder.Entity<tblsoftware>()
                .Property(e => e.officeversion)
                .IsUnicode(false);

            modelBuilder.Entity<tblstaff>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblstatus>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblstatus>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tblstatus>()
                .HasMany(e => e.tblwarranty)
                .WithOptional(e => e.tblstatus)
                .HasForeignKey(e => e.warrantystatus);

            modelBuilder.Entity<tblsystem>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblsystem>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<tblsystem>()
                .Property(e => e.serialno)
                .IsUnicode(false);

            modelBuilder.Entity<tblsystem>()
                .Property(e => e.pno)
                .IsUnicode(false);

            modelBuilder.Entity<tblsystem>()
                .Property(e => e.processor)
                .IsUnicode(false);

            modelBuilder.Entity<tblsystem>()
                .Property(e => e.memory)
                .IsUnicode(false);

            modelBuilder.Entity<tblsystem>()
                .Property(e => e.hdd)
                .IsUnicode(false);

            modelBuilder.Entity<tblsystem>()
                .Property(e => e.dvdcd)
                .IsUnicode(false);

            modelBuilder.Entity<tblsystem>()
                .Property(e => e.operational)
                .IsUnicode(false);

            modelBuilder.Entity<tblsystem>()
                .HasMany(e => e.tbldesktop)
                .WithOptional(e => e.tblsystem)
                .HasForeignKey(e => e.fksystem);

            modelBuilder.Entity<tblsystem>()
                .HasMany(e => e.tbllaptop)
                .WithOptional(e => e.tblsystem)
                .HasForeignKey(e => e.fksystem);

            modelBuilder.Entity<tblsystem>()
                .HasMany(e => e.tblnetwork)
                .WithOptional(e => e.tblsystem)
                .HasForeignKey(e => e.fksystem);

            modelBuilder.Entity<tblsystem>()
                .HasMany(e => e.tblsystem1)
                .WithOptional(e => e.tblsystem2)
                .HasForeignKey(e => e.fksystemtype);

            modelBuilder.Entity<tblsystem>()
                .HasMany(e => e.tblwarranty)
                .WithOptional(e => e.tblsystem)
                .HasForeignKey(e => e.fksystem);

            modelBuilder.Entity<tblups>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblups>()
                .Property(e => e.serialno)
                .IsUnicode(false);

            modelBuilder.Entity<tblups>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<tblvendor>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblvendor>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<tblvendor>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tblvendor>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<tblvendor>()
                .HasMany(e => e.tblbattery)
                .WithOptional(e => e.tblvendor)
                .HasForeignKey(e => e.fkvendor);

            modelBuilder.Entity<tblvendor>()
                .HasMany(e => e.tblkeyboard)
                .WithOptional(e => e.tblvendor)
                .HasForeignKey(e => e.fkvendor);

            modelBuilder.Entity<tblvendor>()
                .HasMany(e => e.tblmonitor)
                .WithOptional(e => e.tblvendor)
                .HasForeignKey(e => e.fkvendor);

            modelBuilder.Entity<tblvendor>()
                .HasMany(e => e.tblmouse)
                .WithOptional(e => e.tblvendor)
                .HasForeignKey(e => e.fkvendor);

            modelBuilder.Entity<tblvendor>()
                .HasMany(e => e.tbloffice)
                .WithOptional(e => e.tblvendor)
                .HasForeignKey(e => e.fkvendor);

            modelBuilder.Entity<tblvendor>()
                .HasMany(e => e.tblos)
                .WithOptional(e => e.tblvendor)
                .HasForeignKey(e => e.fkvendor);

            modelBuilder.Entity<tblvendor>()
                .HasMany(e => e.tblsystem)
                .WithOptional(e => e.tblvendor)
                .HasForeignKey(e => e.fkvendor);

            modelBuilder.Entity<tblvendor>()
                .HasMany(e => e.tblups)
                .WithOptional(e => e.tblvendor)
                .HasForeignKey(e => e.fkvendor);

            modelBuilder.Entity<tblvendor>()
                .HasMany(e => e.tblwarranty)
                .WithOptional(e => e.tblvendor)
                .HasForeignKey(e => e.fkvendor);

            modelBuilder.Entity<tblwarranty>()
                .Property(e => e.assignedto)
                .IsUnicode(false);

            modelBuilder.Entity<tblwarranty>()
                .Property(e => e.preparedby)
                .IsUnicode(false);
        }
    }
}
