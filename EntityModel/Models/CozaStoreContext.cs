using System;
using EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CozaStorev2.Models
{
    public partial class CozaStoreContext : DbContext
    {
        public CozaStoreContext()
        {
        }

        public CozaStoreContext(DbContextOptions<CozaStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<MenuAuths> MenuAuths { get; set; }
        public virtual DbSet<MenuGroups> MenuGroups { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<ProductImages> ProductImages { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<DeviceLocationHistoryAudit> DeviceLocationHistoryAudit { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database=CozaStore;user id=;password=;Trusted_Connection=True;MultipleActiveResultSets=true;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Addr).HasMaxLength(50);

                entity.Property(e => e.Avatar).HasMaxLength(300);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailAddr)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Profile).HasMaxLength(500);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Devices>(entity =>
            {
                entity.Property(e => e.BranchName).HasMaxLength(30);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Origin).HasMaxLength(20);

                entity.Property(e => e.ProductType).HasMaxLength(20);

                entity.Property(e => e.ReceivedDate).HasColumnType("datetime");

                entity.Property(e => e.SerialNumber).HasMaxLength(30);

                entity.HasOne(d => d.CurrentLocation)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.CurrentLocationId)
                    .HasConstraintName("FK__Devices__Current__34C8D9D1");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__Devices__OwnerId__33D4B598");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.Property(e => e.Adrress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AreaCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuAuths>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MenuId });

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MenuGroups>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GroupId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<ProductImages>(entity =>
            {
                entity.HasKey(e => new { e.ProdId, e.ImgPath, e.ImgStatus });

                entity.Property(e => e.ImgPath).HasMaxLength(300);

                entity.Property(e => e.ImgStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dimensions).HasMaxLength(50);

                entity.Property(e => e.Meterials).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.ProfileImg).HasMaxLength(50);

                entity.Property(e => e.Sizes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Avatar).HasMaxLength(300);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<DeviceLocationHistoryAudit>(entity =>
            {
                entity.HasKey(e => e.DlhistoryId);

                entity.ToTable("Device_Location_History_Audit");

                entity.Property(e => e.DlhistoryId)
                    .HasColumnName("DLHistoryId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Activity)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DoneBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewLocation).HasMaxLength(50);
            });
        }
    }
}
