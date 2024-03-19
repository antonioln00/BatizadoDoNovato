using BatizadoDoNovato.Entities;
using Microsoft.EntityFrameworkCore;

namespace BatizadoDoNovato.Context;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base (options) { }

    public DbSet<Login> Logins { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<RegraImposto> RegrasImposto { get; set; }
}
