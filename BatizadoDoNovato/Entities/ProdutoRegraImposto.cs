namespace BatizadoDoNovato.Entities;
public class ProdutoRegraImposto
{
    public int ProdutoCodigo { get; set; }
    public virtual Produto? Produto { get; set; }

    public int RegraImpostoCodigo { get; set; }
    public virtual RegraImposto? RegraImposto { get; set; }
}