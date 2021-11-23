using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_010_A.Models
{
    public partial class pergajianContext : DbContext
    {
        public pergajianContext()
        {
        }

        public pergajianContext(DbContextOptions<pergajianContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Gaji> Gajis { get; set; }
        public virtual DbSet<Golongan> Golongans { get; set; }
        public virtual DbSet<Jabatan> Jabatans { get; set; }
        public virtual DbSet<Karyawan> Karyawans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Gaji>(entity =>
            {
                entity.HasKey(e => e.Idgaji)
                    .HasName("PK_gaji_1");

                entity.ToTable("gaji");

                entity.Property(e => e.Idgaji)
                    .ValueGeneratedNever()
                    .HasColumnName("idgaji");

                entity.Property(e => e.GajiBulan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gaji_bulan");

                entity.Property(e => e.Idkaryawan).HasColumnName("idkaryawan");

                entity.Property(e => e.Lembur).HasColumnName("lembur");

                entity.Property(e => e.Masuk).HasColumnName("masuk");

                entity.Property(e => e.NoSlip).HasColumnName("no_slip");

                entity.Property(e => e.Pph).HasColumnName("pph");

                entity.Property(e => e.SubTotal).HasColumnName("sub_total");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("date")
                    .HasColumnName("tanggal");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdkaryawanNavigation)
                    .WithMany(p => p.Gajis)
                    .HasForeignKey(d => d.Idkaryawan)
                    .HasConstraintName("FK_gaji_karyawan");
            });

            modelBuilder.Entity<Golongan>(entity =>
            {
                entity.HasKey(e => e.Idgolongan)
                    .HasName("PK_golongan_1");

                entity.ToTable("golongan");

                entity.Property(e => e.Idgolongan)
                    .ValueGeneratedNever()
                    .HasColumnName("idgolongan");

                entity.Property(e => e.Golongan1).HasColumnName("golongan");

                entity.Property(e => e.TjKeluarga).HasColumnName("tj_keluarga");

                entity.Property(e => e.TjKesehatan).HasColumnName("tj_kesehatan");

                entity.Property(e => e.UangLembur).HasColumnName("uang_lembur");

                entity.Property(e => e.UangMakan).HasColumnName("uang_makan");
            });

            modelBuilder.Entity<Jabatan>(entity =>
            {
                entity.HasKey(e => e.Idjabatan)
                    .HasName("PK_jabatan_1");

                entity.ToTable("jabatan");

                entity.Property(e => e.Idjabatan)
                    .ValueGeneratedNever()
                    .HasColumnName("idjabatan");

                entity.Property(e => e.Gajipokok).HasColumnName("gajipokok");

                entity.Property(e => e.Jabatan1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("jabatan");

                entity.Property(e => e.TjJabatan).HasColumnName("tj_jabatan");
            });

            modelBuilder.Entity<Karyawan>(entity =>
            {
                entity.HasKey(e => e.Idkaryawan)
                    .HasName("PK_karyawan_1");

                entity.ToTable("karyawan");

                entity.Property(e => e.Idkaryawan)
                    .ValueGeneratedNever()
                    .HasColumnName("idkaryawan");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alamat");

                entity.Property(e => e.Idgolongan).HasColumnName("idgolongan");

                entity.Property(e => e.Idjabatan).HasColumnName("idjabatan");

                entity.Property(e => e.JenisKelamin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("jenis_kelamin");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama");

                entity.Property(e => e.Nip).HasColumnName("nip");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.IdgolonganNavigation)
                    .WithMany(p => p.Karyawans)
                    .HasForeignKey(d => d.Idgolongan)
                    .HasConstraintName("FK_karyawan_golongan");

                entity.HasOne(d => d.IdjabatanNavigation)
                    .WithMany(p => p.Karyawans)
                    .HasForeignKey(d => d.Idjabatan)
                    .HasConstraintName("FK_karyawan_jabatan");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
