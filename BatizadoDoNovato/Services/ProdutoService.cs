using BatizadoDoNovato.Context;
using Microsoft.EntityFrameworkCore;

namespace BatizadoDoNovato.Services;
public class ProdutoService
{
    private readonly ApplicationDbContext _context;

    public ProdutoService(ApplicationDbContext context)
    {
        _context = context;
    }
}