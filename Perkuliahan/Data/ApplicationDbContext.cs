using Microsoft.EntityFrameworkCore;
using Perkuliahan.Models.Entities;

namespace Perkuliahan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
            public DbSet<Mahasiswa> Mahasiswas { get; set; }
            public DbSet<Dosen> Dosens { get; set; }
            public DbSet<MataKuliah> MataKuliahs { get; set; }

            public DbSet<Kuliah> Kuliahs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships here

            // One-to-Many: Mahasiswa to Kuliah
            modelBuilder.Entity<Mahasiswa>()
                .HasMany(m => m.Kuliahs)
                .WithOne(k => k.Mahasiswa)
                .HasForeignKey(k => k.Nim)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-One: Dosen to Kuliah
            modelBuilder.Entity<Dosen>()
                .HasOne(d => d.Kuliah)
                .WithOne(k => k.Dosen)
                .HasForeignKey<Kuliah>(k => k.Nip)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-One: MataKuliah to Kuliah
            modelBuilder.Entity<MataKuliah>()
                .HasMany(mk => mk.Kuliahs)
                .WithOne(k => k.MataKuliah)
                .HasForeignKey(k => k.Kode_MK)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    
    }
}
