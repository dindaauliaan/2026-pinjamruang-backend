using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PinjamRuang.Data;
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

    // ================= CREATE =================
    [HttpPost]
    public async Task<IActionResult> Create(CreateBorrowingDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.NamaPeminjam) ||
            string.IsNullOrWhiteSpace(dto.Keperluan))
        {
            return BadRequest("Field wajib tidak boleh kosong");
        }

        var borrowing = new Borrowing
        {
            RoomId = dto.RoomId,
            NamaPeminjam = dto.NamaPeminjam,
            Keperluan = dto.Keperluan,
            Tanggal = DateTime.Parse(dto.Tanggal),
            Status = "pending"
        };

        _context.Borrowings.Add(borrowing);
        await _context.SaveChangesAsync();

        return Ok(borrowing);
    }

    // ================= GET ALL + FILTER =================
    [HttpGet]
    public async Task<IActionResult> GetBorrowings(
        [FromQuery] string? status,
        [FromQuery] string? nama_peminjam
    )
    {
        var query = _context.Borrowings
            .Where(b => b.DeletedAt == null)
            .Include(b => b.Room)
            .AsQueryable();

        if (!string.IsNullOrEmpty(status))
        {
            var allowed = new[] { "pending", "approved", "rejected" };
            if (!allowed.Contains(status.ToLower()))
                return BadRequest("Status tidak valid");

            query = query.Where(b => b.Status == status.ToLower());
        }

        if (!string.IsNullOrEmpty(nama_peminjam))
        {
            query = query.Where(b =>
                b.NamaPeminjam.Contains(nama_peminjam));
        }

        var result = await query
            .Select(b => new
            {
                b.Id,
                b.NamaPeminjam,
                b.Keperluan,
                b.Tanggal,
                b.Status,
                b.RoomId
            })
            .ToListAsync();

        return Ok(result);
    }

    // ================= GET BY ID =================
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var borrowing = await _context.Borrowings
            .FirstOrDefaultAsync(b => b.Id == id && b.DeletedAt == null);

        if (borrowing == null)
            return NotFound();

        return Ok(borrowing);
    }

    // ================= UPDATE =================
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateBorrowingDto dto)
    {
        var borrowing = await _context.Borrowings.FindAsync(id);

        if (borrowing == null || borrowing.DeletedAt != null)
            return NotFound();

        borrowing.RoomId = dto.RoomId;
        borrowing.NamaPeminjam = dto.NamaPeminjam;
        borrowing.Keperluan = dto.Keperluan;
        borrowing.Tanggal = DateTime.Parse(dto.Tanggal);

        await _context.SaveChangesAsync();
        return Ok(borrowing);
    }

    // ================= DELETE (SOFT) =================
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

    // ================= STATUS =================
    [HttpGet("{id}/status")]
    public async Task<IActionResult> GetStatus(int id)
    {
        var borrowing = await _context.Borrowings
            .FirstOrDefaultAsync(b => b.Id == id && b.DeletedAt == null);

        if (borrowing == null)
            return NotFound();

        return Ok(new { status = borrowing.Status });
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, UpdateBorrowingStatusDto dto)
    {
        var allowed = new[] { "pending", "approved", "rejected" };
        if (!allowed.Contains(dto.Status))
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
