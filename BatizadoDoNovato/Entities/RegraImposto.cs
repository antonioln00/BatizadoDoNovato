namespace BatizadoDoNovato.Entities;
public class RegraImposto
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public int Taxa { get; set; }
    public virtual IList<ProdutoRegraImposto>? ProdutosRegrasImpostos { get; set; }
}