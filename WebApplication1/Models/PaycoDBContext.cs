using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Api.Models
{
    public partial class PaycoDBContext : DbContext
    {
        public PaycoDBContext()
        {
        }

        public PaycoDBContext(DbContextOptions<PaycoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<DeviceManagement> DeviceManagements { get; set; }
        public virtual DbSet<DocumentStat> DocumentStats { get; set; }
        public virtual DbSet<GroupManagement> GroupManagements { get; set; }
        public virtual DbSet<GroupManagement1> GroupManagements1 { get; set; }
        public virtual DbSet<MailingList> MailingLists { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               // optionsBuilder.UseSqlServer("Server=.;Database=PaycoDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecurePassword)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeviceManagement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DeviceManagement");

                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.DeviceImei)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DeviceIMEI");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LastLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnType("date");

                entity.Property(e => e.RegisteredDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<DocumentStat>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descriptions).HasColumnType("text");

                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.DocId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DocID");

                entity.Property(e => e.DocumentType).HasColumnType("text");

                entity.Property(e => e.FileFormat).HasColumnType("text");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Img)
                    .HasColumnType("text")
                    .HasColumnName("IMG");

                entity.Property(e => e.Locations).HasColumnType("text");

                entity.Property(e => e.SentDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<GroupManagement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GroupManagement");

                entity.Property(e => e.GroupId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("GroupID");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupManagement1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GroupManagements");

                entity.Property(e => e.GroupId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("GroupID");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MailingList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MailingList");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.MailId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MailID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Report");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Ipaddress)
                    .HasColumnType("text")
                    .HasColumnName("IPAddress");

                entity.Property(e => e.LastActivity).HasColumnType("text");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SiteId).HasColumnName("SiteID");

                entity.Property(e => e.UserAgent).HasColumnType("text");

                entity.Property(e => e.UserData).HasColumnType("text");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("site");

                entity.Property(e => e.SiteName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SiteUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SiteURL");
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CellPhone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
