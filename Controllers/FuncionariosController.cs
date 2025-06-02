using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class FuncionariosController : ControllerBase
{
    private readonly AppDbContext _context;

    public FuncionariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Funcionario funcionario)
    {
        if (funcionario.Cargo == "Gerente" && string.IsNullOrWhiteSpace(funcionario.Email))
            return BadRequest("Email é obrigatório para Gerentes.");

        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = funcionario.Id }, funcionario);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var funcionarios = await _context.Funcionarios
            .Include(f => f.Equipe)
            .ToListAsync();
        return Ok(funcionarios);
    }
}
