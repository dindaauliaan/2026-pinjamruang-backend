# 2026-pinjamruang-backend

## deskripsi 
Sistem Peminjaman Ruangan Kampus adalah aplikasi backend berbasis ASP.NET Web API yang digunakan untuk mengelola proses peminjaman ruangan di lingkungan kampus.
Sistem ini memungkinkan pengguna untuk mengajukan peminjaman ruangan, melihat riwayat peminjaman, serta memantau status pengajuan. Administrator dapat mengelola data ruangan, data peminjaman, dan menyetujui atau menolak pengajuan peminjaman.

Proyek ini dikembangkan sebagai bagian dari Tugas Pra Proyek PBL.

## Fitur Utama
1. CRUD Peminjaman Ruangan
2. Pengelolaan Status Peminjaman (pending, approved, rejected)
3. Riwayat dan Penelusuran Peminjaman : 
    - Filter berdasarkan status
    - Pencarian berdasarkan nama peminjam

## Teknologi yang digunakan
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / Swashbuckle
- C#
- Git & GitHub

## Struktur Projek
2026-pinjamruang-backend
│
├── Controllers
│   ├── RoomsController.cs
│   └── BorrowingsController.cs
│
├── Data
│   └── AppDbContext.cs
│
├── DTOs
│   ├── Room
│   └── Borrowing
│
├── Entities
│   ├── Room.cs
│   └── Borrowing.cs
│
├── Migrations
├── Program.cs
└── README.md

## Konfigurasi Environment
- .NET SDK (minimal .NET 7)
- SQL Server 22
- VS Code

## Konfigurasi Database
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=PinjamRuangDb;Trusted_Connection=True;TrustServerCertificate=True"
}

## Cara Menjalankan Aplikasi
1. Clone Repository
    git clone https://github.com/dindaauliaan/2026-pinjamruang-backend.git
2. Restore Dependency
    dotnet restore
3. Jalankan Migrasi Database
    dotnet ef database update
4. Jalankan Aplikasi
    dotnet run