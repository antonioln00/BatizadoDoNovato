using BatizadoDoNovato.Context;
using BatizadoDoNovato.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BatizadoDoNovato.Controllers;
[ApiController]
[Route("[controller]")]
public class RegraImpostoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RegraImpostoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<RegraImposto>>> ObterTodos() =>
        Ok(await _context.Produtos.ToListAsync());

    [HttpPost("nova-regra-imposto")]
    public async Task<ActionResult<RegraImposto>> NovaRegraImposto([FromBody] RegraImposto model)
    {
        try
        {
            if (model == null)
                return BadRequest("Dados inseridos inválidos.");

            var novaRegraImposto = new RegraImposto {
                Nome = model.Nome,
                Taxa = model.Taxa,
                ProdutoId = model.ProdutoId
            };

            if (novaRegraImposto == null)
                return BadRequest("Nova regra de imposto é inválida.");

            _context.RegrasImposto.Add(novaRegraImposto);
            await _context.SaveChangesAsync();

            return Ok(model);
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    [HttpPut("atualizar-regra-imposto/{id:int}")]
    public async Task<ActionResult<RegraImposto>> AtualizarRegraImposto(int id, RegraImposto model)
    {
        try
        {
            if (model == null)
                return BadRequest("Dados inseridos inválidos.");

            var regraImposto = await _context.RegrasImposto.FindAsync(id);

            if (regraImposto == null)
                return BadRequest($"Regra de imposto de ID {id} não existe.");

            regraImposto.Nome = model.Nome;
            regraImposto.Taxa = model.Taxa;
            
            _context.RegrasImposto.Update(regraImposto);
            await _context.SaveChangesAsync();

            return Ok(model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpDelete("deletar-regra-imposto/{id}")]
    public async Task<ActionResult> DeletarRegraImposto(int id)
    {
        try
        {
            var regraImposto = await _context.RegrasImposto
                .FirstOrDefaultAsync(e => e.Codigo == id);

            if (regraImposto == null)
                return BadRequest($"Regra de imposto de ID {id} não existe.");

            _context.RegrasImposto.Remove(regraImposto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}
