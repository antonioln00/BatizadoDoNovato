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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Login>().HasNoKey();
        modelBuilder.Entity<RegraImposto>().HasKey(e => e.Codigo);
        modelBuilder.Entity<Produto>().HasKey(e => e.Codigo);

        modelBuilder.Entity<Login>().Property(e => e.Usuario).HasAnnotation("MaxLength", 10);
        modelBuilder.Entity<Login>().Property(e => e.Usuario).HasAnnotation("Regular Expression", @"^[A-Z]+$");
        modelBuilder.Entity<Login>().Property(e => e.Senha).HasAnnotation("Regular Expression",  @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8, 15}$");

        modelBuilder.Entity<RegraImposto>().Property(e => e.Nome).HasAnnotation("MaxLength", 50);
        modelBuilder.Entity<RegraImposto>().Property(e => e.Taxa).HasMaxLength(3);

        modelBuilder.Entity<Produto>().Property(e => e.Nome).HasAnnotation("MaxLength", 50);
        modelBuilder.Entity<Produto>().Property(e => e.PrecoCusto).HasPrecision(12,2);
        modelBuilder.Entity<Produto>().Property(e => e.Markup).HasPrecision(8,2);
        modelBuilder.Entity<Produto>().Property(e => e.PrecoVenda).HasPrecision(12,2);
        modelBuilder.Entity<Produto>().Property(e => e.MargemReal).HasPrecision(8,2);

        modelBuilder
            .Entity<RegraImposto>() // Na tabela Regra Imposto
            .HasOne(e => e.Produto) // tem um produto
            .WithMany(e => e.RegrasImposto) // para muitas regras de imposto
            .HasForeignKey(e => e.ProdutoId) // referenciados pela chave estrangeira produtoId
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