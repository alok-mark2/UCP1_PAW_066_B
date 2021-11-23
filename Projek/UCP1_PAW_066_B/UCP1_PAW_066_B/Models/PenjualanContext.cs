using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_066_B.Models
{
    public partial class PenjualanContext : DbContext
    {
        public PenjualanContext()
        {
        }

        public PenjualanContext(DbContextOptions<PenjualanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admind> Adminds { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Produk> Produks { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admind>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admind");

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.NamaAdmin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_admin");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_customer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .HasColumnName("alamat");

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_customer");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(10)
                    .HasColumnName("telephone")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customers_Transaksi");
            });

            modelBuilder.Entity<Produk>(entity =>
            {
                entity.HasKey(e => e.IdProduk);

                entity.Property(e => e.IdProduk)
                    .ValueGeneratedNever()
                    .HasColumnName("id_produk");

                entity.Property(e => e.NamaProduk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_produk");

                entity.Property(e => e.Quantity)
                    .HasMaxLength(10)
                    .HasColumnName("quantity")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi).HasColumnName("id_transaksi");

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.IdProduk).HasColumnName("id_produk");

                entity.Property(e => e.TotalTransaksi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("total_transaksi");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK_Transaksi_Admind");

                entity.HasOne(d => d.IdProdukNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdProduk)
                    .HasConstraintName("FK_Transaksi_Produks");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
