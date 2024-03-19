namespace BatizadoDoNovato.Entities;
public class RegraImposto
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public int Taxa { get; set; }
    public int ProdutoId { get; set; }
    public virtual Produto? Produto { get; set; }
}