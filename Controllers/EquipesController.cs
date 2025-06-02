using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class EquipesController : ControllerBase
{
    private readonly AppDbContext _context;

    public EquipesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Equipe equipe)
    {
        _context.Equipes.Add(equipe);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = equipe.Id }, equipe);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var equipes = await _context.Equipes.ToListAsync();
        return Ok(equipes);
    }
}
