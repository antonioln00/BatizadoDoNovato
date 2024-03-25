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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegraImposto>>> ObterTodos() =>
        Ok(await _context.RegrasImposto.Select(ri => new {
            ri.Codigo,
            ri.Nome,
            ri.Taxa,
            Produtos = ri.ProdutosRegrasImpostos.Where(e => e.ProdutoCodigo == e.Produto.Codigo).Select(produto => new {
                produto.Produto.Codigo,
                produto.Produto.Nome,
                produto.Produto.PrecoCusto,
                produto.Produto.Markup,
                produto.Produto.PrecoVenda,
                produto.Produto.MargemReal
            })
        }).ToListAsync());

    [HttpPost]
    public async Task<ActionResult<RegraImposto>> NovaRegraImposto([FromBody] RegraImposto model)
    {
        try
        {
            if (model == null)
                return BadRequest("Dados inseridos inválidos.");

            var novaRegraImposto = new RegraImposto {
                Nome = model.Nome,
                Taxa = model.Taxa,
            };

            if (novaRegraImposto == null)
                return BadRequest("Nova regra de imposto é inválida.");

            if (string.IsNullOrEmpty(novaRegraImposto.Nome))
                return BadRequest("O nome da regra de imposto é obrigatório.");

            if (novaRegraImposto.Taxa == 0)
                return BadRequest("A taxa da regra de imposto é obrigatória.");

            _context.RegrasImposto.Add(novaRegraImposto);
            await _context.SaveChangesAsync();

            return Ok(model);
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    [HttpPut("{id:int}")]
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

    [HttpDelete("{id}")]
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
