using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCore.Models;

public partial class QlbookstoreContext : DbContext
{
    public QlbookstoreContext()
    {
    }

    public QlbookstoreContext(DbContextOptions<QlbookstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }

    public virtual DbSet<Chude> Chudes { get; set; }

    public virtual DbSet<Dondathang> Dondathangs { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Nhaxuatban> Nhaxuatbans { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<Tacgium> Tacgia { get; set; }

    public virtual DbSet<Vietsach> Vietsaches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-4N22J8U\\MSSQLSEVER01;Initial Catalog=QLBOOKSTORE;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Vietnamese_CI_AS");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__ADMIN__719FE4E80E83D5F6");

            entity.ToTable("ADMIN");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.HoTen)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Chitietdonhang>(entity =>
        {
            entity.HasKey(e => new { e.MaDonHang, e.MaSach });

            entity.ToTable("CHITIETDONHANG");

            entity.Property(e => e.Dongia).HasColumnType("money");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.MaDonHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHITIETDONHANG_DONDATHANG");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHITIETDONHANG_SACH");
        });

        modelBuilder.Entity<Chude>(entity =>
        {
            entity.HasKey(e => e.MaCd);

            entity.ToTable("CHUDE");

            entity.Property(e => e.MaCd).HasColumnName("MaCD");
            entity.Property(e => e.TenChuDe)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Dondathang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang);

            entity.ToTable("DONDATHANG");

            entity.Property(e => e.Dathanhtoan)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.Ngaydat)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Ngaygiao)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Tinhtranggiaohang)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.Dondathangs)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DONDATHANG_KHACHHANG");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.MaKh);

            entity.ToTable("KHACHHANG");

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.DiaChiKh)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("DiaChiKH");
            entity.Property(e => e.DienThoaiKh).HasColumnName("DienThoaiKH");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.TaiKhoan)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Nhaxuatban>(entity =>
        {
            entity.HasKey(e => e.MaNxb);

            entity.ToTable("NHAXUATBAN");

            entity.Property(e => e.MaNxb).HasColumnName("MaNXB");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.TenNxb)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("TenNXB");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.Masach);

            entity.ToTable("SACH");

            entity.Property(e => e.Anhbia)
                .HasMaxLength(150)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Giaban).HasColumnType("money");
            entity.Property(e => e.MaCd).HasColumnName("MaCD");
            entity.Property(e => e.MaNxb).HasColumnName("MaNXB");
            entity.Property(e => e.Mota)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnType("text");
            entity.Property(e => e.Tensach)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.MaCdNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaCd)
                .HasConstraintName("FK_SACH_CHUDE");

            entity.HasOne(d => d.MaNxbNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaNxb)
                .HasConstraintName("FK_SACH_NHAXUATBAN");
        });

        modelBuilder.Entity<Tacgium>(entity =>
        {
            entity.HasKey(e => e.MaTg);

            entity.ToTable("TACGIA");

            entity.Property(e => e.MaTg).HasColumnName("MaTG");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.TenTg)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("TenTG");
            entity.Property(e => e.TieuSu)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnType("text");
        });

        modelBuilder.Entity<Vietsach>(entity =>
        {
            entity.HasKey(e => new { e.MaTg, e.Masach });

            entity.ToTable("VIETSACH");

            entity.Property(e => e.MaTg).HasColumnName("MaTG");
            entity.Property(e => e.Vaitro)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Vitri)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnType("text");

            entity.HasOne(d => d.MaTgNavigation).WithMany(p => p.Vietsaches)
                .HasForeignKey(d => d.MaTg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VIETSACH_TACGIA");

            entity.HasOne(d => d.MasachNavigation).WithMany(p => p.Vietsaches)
                .HasForeignKey(d => d.Masach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VIETSACH_SACH");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
