using BatizadoDoNovato.Context;
using BatizadoDoNovato.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BatizadoDoNovato.Controllers;
[ApiController]
[Route("[controller]")]
public class ProdutoRegraImpostoController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public ProdutoRegraImpostoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("adicionar-produto-regra-imposto/{produtoCodigo:int}/{regraImpostoCodigo:int}")]
    public async Task<ActionResult> AdicionarProdutoRegraImposto(int produtoCodigo, int regraImpostoCodigo)
    {
        try
        {
            var produto = await _context.Produtos.FindAsync(produtoCodigo);
            if (produto == null)
                return BadRequest($"Produto de ID {produtoCodigo} não existe.");

            var regraImposto = await _context.RegrasImposto.FindAsync(regraImpostoCodigo);
            if (regraImposto == null)
                return BadRequest($"Regra de imposto de ID {regraImpostoCodigo} não existe.");

            var produtoRegraImposto = await _context.ProdutosRegrasImposto
                .FirstOrDefaultAsync(e => e.ProdutoCodigo == produtoCodigo &&
                                            e.RegraImpostoCodigo == regraImpostoCodigo);
            if (produtoRegraImposto != null)
                return BadRequest($"A relação entre o Produto {produtoCodigo} e a Regra de imposto {regraImpostoCodigo} já existe.");
            
            var novoProdutoRegraImposto = new ProdutoRegraImposto 
            {
                ProdutoCodigo = produtoCodigo,
                RegraImpostoCodigo = regraImpostoCodigo   
            };

            _context.ProdutosRegrasImposto.Add(novoProdutoRegraImposto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
