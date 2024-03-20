using BatizadoDoNovato.Context;
using BatizadoDoNovato.Entities;
using BatizadoDoNovato.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BatizadoDoNovato.Controllers;
[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ProdutoService _produtoService;
    public ProdutoController(ApplicationDbContext context, ProdutoService produtoService)
    {
        _context = context;
        _produtoService = produtoService;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<Produto>>> ObterTodos() =>
        Ok(await _context.Produtos.Select(produto => new {
            produto.Codigo,
            produto.Nome,
            produto.PrecoCusto,
            produto.Markup,
            produto.PrecoVenda,
            produto.MargemReal,
            RegrasImposto = produto.ProdutosRegrasImpostos.Select(pri => new {
                pri.RegraImposto.Codigo,
                pri.RegraImposto.Nome,
                pri.RegraImposto.Taxa
            })
        }).ToListAsync());

    [HttpPost("novo-produto")]
    public async Task<ActionResult<Produto>> NovoProduto([FromBody] Produto model)
    {
        try
        {
            if (model == null)
                return BadRequest("Dados inseridos inválidos.");

            var novoProduto = new Produto
            {
                Nome = model.Nome,
                PrecoCusto = model.PrecoCusto,
                Markup = model.Markup,
                PrecoVenda = model.PrecoVenda
            };

            if (novoProduto == null)
                return BadRequest("Novo produto inválido.");

            if (model.Markup == 0)
                novoProduto.Markup = _produtoService.CalculoMarkup(model.PrecoCusto, (decimal)model.PrecoVenda);
       
            if (model.PrecoVenda == 0)
                novoProduto.PrecoVenda = _produtoService.CalculoPrecoVenda(model.PrecoCusto, (decimal)model.Markup);
            
            if (model.MargemReal == 0)
                novoProduto.MargemReal = _produtoService.CalculoMargemReal(model.PrecoCusto, (decimal)novoProduto.PrecoVenda);


            _context.Produtos.Add(novoProduto);
            await _context.SaveChangesAsync();

            return Ok(novoProduto);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpPut("alterar-produto/{id:int}")]
    public async Task<ActionResult<Produto>> AlterarProduto(int id, Produto model)
    {
        try
        {
            if (model == null)
                return BadRequest("Dados inseridos inválidos.");

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return BadRequest($"Produto de ID {id} não existe.");

            produto.Nome = model.Nome;
            produto.PrecoCusto = model.PrecoCusto;
            produto.Markup = model.Markup;
            produto.PrecoVenda = model.PrecoVenda;
            produto.MargemReal = model.MargemReal;

            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();

            return Ok(model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpDelete("deletar-produto/{id}")]
    public async Task<ActionResult> DeletarProduto(int id)
    {
        try
        {
            var produto = await _context.Produtos
                .FirstOrDefaultAsync(e => e.Codigo == id);

            if (produto == null)
                return BadRequest($"Produto de ID {id} não existe.");

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception)
        {

            throw;
        }
    }
}