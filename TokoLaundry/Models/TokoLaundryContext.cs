using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TokoLaundry.Models
{
    public partial class TokoLaundryContext : DbContext
    {
        public TokoLaundryContext()
        {
        }

        public TokoLaundryContext(DbContextOptions<TokoLaundryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Admin");

                entity.Property(e => e.NamaAdmin)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Admin");

                entity.Property(e => e.NoTelpon)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("No_Telpon");
            });

            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.ToTable("Barang");

                entity.Property(e => e.IdBarang)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Barang");

                entity.Property(e => e.HargaBarang).HasColumnName("Harga_Barang");

                entity.Property(e => e.JenisBarang)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Jenis_Barang");

                entity.Property(e => e.NamaBarang)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Barang");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Customer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Customer");

                entity.Property(e => e.NoTelpon)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("No_Telpon");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Transaksi");

                entity.Property(e => e.Catatan)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");

                entity.Property(e => e.IdBarang).HasColumnName("ID_Barang");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.Tanggal).HasColumnType("datetime");

                entity.Property(e => e.TotalTransaksi).HasColumnName("Total_Transaksi");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK_Transaksi_Admin");

                entity.HasOne(d => d.IdAdmin1)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK_Transaksi_Barang");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdBarang)
                    .HasConstraintName("FK_Transaksi_Customer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
