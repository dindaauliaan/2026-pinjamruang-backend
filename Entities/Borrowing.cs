namespace PinjamRuang.Entities
{
    public class Borrowing
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; } 

        public required string NamaPeminjam { get; set; }
        public required string Keperluan { get; set; }

        public DateTime Tanggal { get; set; }


        public string Status { get; set; } = "pending";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }

}
