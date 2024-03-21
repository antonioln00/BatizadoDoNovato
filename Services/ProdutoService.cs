namespace BatizadoDoNovato.Services;
public class ProdutoService
{
    public decimal CalculoMarkup(decimal pc, decimal pv)
    {
        decimal markup = (pv - pc) / pc;
        decimal markupPorcento = markup * 100;

        return markupPorcento;
    }

    public decimal CalculoPrecoVenda(decimal pc, decimal m)
    {
        decimal markupPorcento = m/100;
        decimal precoVenda = (markupPorcento * pc) + pc;

        return precoVenda;
    }

    public decimal CalculoMargemReal(decimal pc, decimal pv)
    {
        decimal lucro = pv - pc;
        decimal margemReal = lucro/pv;
        decimal margemRealPorcento = margemReal * 100;

        return margemRealPorcento;
    }
}