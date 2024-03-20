namespace BatizadoDoNovato.Entities;
public class Produto
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public decimal PrecoCusto { get; set; }
    public decimal? Markup { get; set; } 
    public decimal? PrecoVenda { get; set; }
    public decimal? MargemReal { get; set; }
    public virtual IList<ProdutoRegraImposto>? ProdutosRegrasImpostos { get; set; }
    public Produto()
    {
        PrecoCusto = 0.00m;
        Markup = 0.00m;
        PrecoVenda = 0.00m;
        MargemReal = 0.00m;
    }
}