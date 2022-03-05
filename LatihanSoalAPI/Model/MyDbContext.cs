using Microsoft.EntityFrameworkCore;

namespace LatihanSoalAPI.Model
{
    public class MyDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        public DbSet<MsPelanggan> MsPelanggan { get; set; }
        public DbSet<MsProduct> MsProduct { get; set; }
        public DbSet<Transaksi> Transaksi { get; set; }
        public DbSet<TransaksiDetail> TransaksiDetail { get; set; }

        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        protected override void OnModelCreating(ModelBuilder modelBuilder)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            modelBuilder.Entity<MsPelanggan>(entity =>
            {
                entity.ToTable("MsPelanggan");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int");

                entity.Property(e => e.Nama)
                    .IsRequired()
                    .HasColumnName("Nama")
                    .HasColumnType("text");

                entity.Property(e => e.Alamat)
                    .IsRequired()
                    .HasColumnName("Alamat")
                    .HasColumnType("text");

                entity.Property(e => e.NoTelp)
                    .IsRequired()
                    .HasColumnName("NoTelp")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<MsProduct>(entity =>
            {
                entity.ToTable("MsProduct");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int");

                entity.Property(e => e.Nama)
                    .IsRequired()
                    .HasColumnName("Nama")
                    .HasColumnType("text");

                entity.Property(e => e.Harga)
                    .IsRequired()
                    .HasColumnName("Harga")
                    .HasColumnType("decimal");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("Deskripsi")
                    .HasColumnType("text");

            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.ToTable("Transaksi");

                entity.HasIndex(e => e.PelangganId)
                .HasName("PelangganId");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int");

                entity.Property(e => e.PelangganId)
                    .HasColumnName("PelangganId")
                    .HasColumnType("int");

                entity.Property(e => e.KodeTransaksi)
                    .IsRequired()
                    .HasColumnName("KodeTransaksi")
                    .HasColumnType("text");

                entity.Property(e => e.Tanggal)
                    .IsRequired()
                    .HasColumnName("Tanggal")
                    .HasColumnType("date");

                entity.HasOne(d => d.Pelanggan)
                    .WithMany(p => p.Transaksi)
                    .HasForeignKey(d => d.PelangganId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transaksi_ibfk_1");
            });

            modelBuilder.Entity<TransaksiDetail>(entity =>
            {
                entity.ToTable("TransaksiDetail");

                entity.HasIndex(e => e.TransaksiId)
                .HasName("Transaksi_Id");

                entity.HasIndex(e => e.ProductId)
                .HasName("Product_Id");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int");

                entity.Property(e => e.TransaksiId)
                    .HasColumnName("TransaksiId")
                    .HasColumnType("int");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductId")
                    .HasColumnType("int");

                entity.Property(e => e.Harga)
                    .IsRequired()
                    .HasColumnName("Harga")
                    .HasColumnType("decimal");

                entity.Property(e => e.Jumlah)
                    .IsRequired()
                    .HasColumnName("Jumlah")
                    .HasColumnType("int");

                entity.HasOne(d => d.Transaksi)
                    .WithMany(p => p.TransaksiDetail)
                    .HasForeignKey(d => d.TransaksiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transaksi_ibfk_1");

                entity.HasOne(d => d.Produk)
                    .WithMany(p => p.TransaksiDetail)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transaksi_ibfk_2");
            });
        }
    }
}
