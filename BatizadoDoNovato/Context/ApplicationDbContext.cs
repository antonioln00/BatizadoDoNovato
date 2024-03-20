using BatizadoDoNovato.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BatizadoDoNovato.Context;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base (options) { }

    public DbSet<Login> Logins { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<RegraImposto> RegrasImposto { get; set; }
    public DbSet<ProdutoRegraImposto> ProdutosRegrasImposto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Login>().HasNoKey();
        modelBuilder.Entity<RegraImposto>().HasKey(e => e.Codigo);
        modelBuilder.Entity<Produto>().HasKey(e => e.Codigo);
        modelBuilder.Entity<ProdutoRegraImposto>().HasKey(e => new { e.ProdutoCodigo, e.RegraImpostoCodigo });

        modelBuilder.Entity<RegraImposto>().Property(e => e.Taxa).HasPrecision(5,2);

        modelBuilder.Entity<Produto>().Property(e => e.Nome).HasAnnotation("MaxLength", 50);
        modelBuilder.Entity<Produto>().Property(e => e.PrecoCusto).HasPrecision(12,2);
        modelBuilder.Entity<Produto>().Property(e => e.Markup).HasPrecision(8,2);
        modelBuilder.Entity<Produto>().Property(e => e.PrecoVenda).HasPrecision(12,2);
        modelBuilder.Entity<Produto>().Property(e => e.MargemReal).HasPrecision(8,2);

        modelBuilder
            .Entity<ProdutoRegraImposto>() // Na tabela ProdutoRegraImposto
            .HasOne(e => e.Produto) // tem um produto
            .WithMany(e => e.ProdutosRegrasImpostos) // para muitos produtos regras de imposto
            .HasForeignKey(e => e.ProdutoCodigo) // referenciados pela chave estrangeira ProdutoCodigo
            .IsRequired();

        modelBuilder
            .Entity<ProdutoRegraImposto>()
            .HasOne(e => e.RegraImposto)
            .WithMany(e => e.ProdutosRegrasImpostos)
            .HasForeignKey(e => e.RegraImpostoCodigo)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("DefaultConnection");
        base.OnConfiguring(optionsBuilder);
    }
}
