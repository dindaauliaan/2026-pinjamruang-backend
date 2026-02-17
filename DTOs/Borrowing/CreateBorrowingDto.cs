public class CreateBorrowingDto
{
    public int RoomId { get; set; }
    public string NamaPeminjam { get; set; } = string.Empty;
    public string Keperluan { get; set; } = string.Empty;
    public string Tanggal { get; set; } = string.Empty;
}
