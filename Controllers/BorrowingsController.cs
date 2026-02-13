using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PinjamRuang.Data;
using PinjamRuang.DTOs.Room;
using PinjamRuang.Entities;
[ApiController]
[Route("borrowings")]
public class BorrowingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BorrowingsController(AppDbContext context)
    {
        _context = context;
    }
    //create borrowing
    [HttpPost]
    public async Task<IActionResult> Create(CreateBorrowingDto dto)
    {
        if (string.IsNullOrEmpty(dto.NamaPeminjam) || string.IsNullOrEmpty(dto.Keperluan))
            return BadRequest("Field wajib tidak boleh kosong");

        var borrowing = new Borrowing
        {
            RoomId = dto.RoomId,
            NamaPeminjam = dto.NamaPeminjam,
            Keperluan = dto.Keperluan,
            Tanggal = dto.Tanggal,
            Status = "pending",

        };

        _context.Borrowings.Add(borrowing);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = borrowing.Id }, borrowing);
    }
    //get all borrowings
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _context.Borrowings
            .Where(b => b.DeletedAt == null)
            .Include(b => b.Room)
            .ToListAsync();

        return Ok(data);
    }
    //get borrowing by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var borrowing = await _context.Borrowings
            .Include(b => b.Room)
            .FirstOrDefaultAsync(b => b.Id == id && b.DeletedAt == null);

        if (borrowing == null)
            return NotFound();

        return Ok(borrowing);
    }
    //update borrowing
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateBorrowingDto dto)
    {
        var borrowing = await _context.Borrowings.FindAsync(id);

        if (borrowing == null || borrowing.DeletedAt != null)
            return NotFound();

        borrowing.RoomId = dto.RoomId;
        borrowing.NamaPeminjam = dto.NamaPeminjam;
        borrowing.Keperluan = dto.Keperluan;
        borrowing.Tanggal = dto.Tanggal;

        await _context.SaveChangesAsync();
        return Ok(borrowing);
    }
    //delete borrowing (soft delete)
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var borrowing = await _context.Borrowings.FindAsync(id);

        if (borrowing == null)
            return NotFound();

        borrowing.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return NoContent();
    }
    //get borrowing status
    [HttpGet("{id}/status")]
    public async Task<IActionResult> GetStatus(int id)
    {
        var borrowing = await _context.Borrowings
            .FirstOrDefaultAsync(b => b.Id == id && b.DeletedAt == null);

        if (borrowing == null)
            return NotFound();

        return Ok(new { status = borrowing.Status });
    }
    //update borrowing status
    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, UpdateBorrowingStatusDto dto)
    {
        var allowedStatus = new[] { "pending", "approved", "rejected" };

        if (!allowedStatus.Contains(dto.Status))
            return BadRequest("Status tidak valid");

        var borrowing = await _context.Borrowings
            .FirstOrDefaultAsync(b => b.Id == id && b.DeletedAt == null);

        if (borrowing == null)
            return NotFound();

        borrowing.Status = dto.Status;
        await _context.SaveChangesAsync();

        return Ok(new { status = borrowing.Status });
    }

}