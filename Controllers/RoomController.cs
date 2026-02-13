using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PinjamRuang.Data;
using PinjamRuang.DTOs.Room;
using PinjamRuang.Entities;

namespace PinjamRuang.Controllers;

[ApiController]
[Route("api/ruangan")]
public class RoomController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomController(AppDbContext context)
    {
        _context = context;
    }

    //GET LIST + SEARCH + PAGINATION
    [HttpGet]
    public async Task<IActionResult> GetAll(
        string? search,
        int page = 1,
        int pageSize = 10)
    {
        var query = _context.Rooms
            .Where(r => r.DeletedAt == null);

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(r =>
                r.Name.Contains(search) ||
                r.Location.Contains(search));
        }

        var data = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(r => new RoomResponseDto
            {
                Id = r.Id,
                Name = r.Name,
                Location = r.Location,
                Capacity = r.Capacity,
                Status = r.Status,
                Description = r.Description
            })
            .ToListAsync();

        return Ok(data);
    }
    //POST (CREATE)
    [HttpPost]
    public async Task<IActionResult> Create(RoomCreateDto dto)
    {
        var room = new Room
        {
            Name = dto.Name,
            Location = dto.Location,
            Capacity = dto.Capacity,
            Status = dto.Status,
            Description = dto.Description
        };

        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
    }

    //GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ruangan = await _context.Rooms
            .FirstOrDefaultAsync(r => r.Id == id && r.DeletedAt == null);

        if (ruangan == null)
            return NotFound();

        return Ok(ruangan);
    }

    //UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, RoomUpdateDto dto)
    {
        var ruangan = await _context.Rooms.FindAsync(id);
        if (ruangan == null) return NotFound();

        ruangan.Name = dto.Name;
        ruangan.Location = dto.Location;
        ruangan.Capacity = dto.Capacity;
        ruangan.Status = dto.Status;
        ruangan.Description = dto.Description;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    //SOFT DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ruangan = await _context.Rooms.FindAsync(id);
        if (ruangan == null) return NotFound();
        ruangan.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
