using Microsoft.EntityFrameworkCore;
using PinjamRuang.Entities;

namespace PinjamRuang.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1, Name = "Ruang A101", Location = "Gedung A", Capacity = 40, Status = "available", Description = "Ruang kelas lantai 1" },
            new Room { Id = 2, Name = "Ruang B202", Location = "Gedung B", Capacity = 30, Status = "available", Description = "Ruang rapat" },
            new Room { Id = 3, Name = "Aula Utama", Location = "Gedung Serbaguna", Capacity = 200, Status = "unavailable", Description = "Untuk acara besar" },
            new Room { Id = 4, Name = "Lab Komputer 1", Location = "Gedung C", Capacity = 25, Status = "available" },
            new Room { Id = 5, Name = "Ruang D303", Location = "Gedung D", Capacity = 35, Status = "available" }
        ); // <--- KURUNG TUTUP HASDATA HARUS DI SINI

        // Sekarang baru konfigurasi untuk Borrowing
        modelBuilder.Entity<Borrowing>()
            .Property(b => b.Status)
            .HasDefaultValue("pending");
    }
        public DbSet<Borrowing> Borrowings { get; set; }
    }
    
}

