using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Game.Model.Entities
{
    public partial class GameStoreContext : DbContext
    {
        public GameStoreContext()
        {
        }

        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChanTrang> ChanTrangs { get; set; } = null!;
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; } = null!;
        public virtual DbSet<DonHang> DonHangs { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<MenuGroup> MenuGroups { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<Slide> Slides { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Users> Userss { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-B1P0DK29;Database=GameStore;integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {

                entity.ToTable("Users");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Age).HasColumnType("datetime");

            });

            modelBuilder.Entity<Login>(entity =>
            {
                
                entity.ToTable("Loginn");

                
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            });
            modelBuilder.Entity<ChanTrang>(entity =>
            {
                entity.ToTable("ChanTrang");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ChiTietDonHang");

                entity.Property(e => e.BillDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PaymentMethod).HasMaxLength(250);

                entity.Property(e => e.PaymentStatus).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__ChiTietDo__Order__108B795B");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ChiTietDo__Produ__117F9D94");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Note).HasMaxLength(500);
            });

            modelBuilder.Entity<DanhMucSanPham>(entity =>
            {
                entity.ToTable("DanhMucSanPham");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.MoTa).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.ToTable("DonHang");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CustomeId).HasColumnName("CustomeID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Custome)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.CustomeId)
                    .HasConstraintName("FK__DonHang__Custome__0EA330E9");

                entity.HasOne(d => d.CustomeNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.CustomeId)
                    .HasConstraintName("FK__DonHang__Product__0DAF0CB0");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__Menus__GroupID__1A14E395");
            });

            modelBuilder.Entity<MenuGroup>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("SanPham");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Descriptions).HasMaxLength(500);

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.Property(e => e.MoTaCh)
                    .HasMaxLength(500)
                    .HasColumnName("MoTaCH");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Promotion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__SanPham__Categor__0519C6AF");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.ToTable("Slide");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("URL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
