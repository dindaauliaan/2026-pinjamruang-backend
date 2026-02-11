namespace PinjamRuang.DTOs.Room;

public class RoomUpdateDto
{
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public int Capacity { get; set; }
    public string Status { get; set; } = "available";
    public string? Description { get; set; }
}
