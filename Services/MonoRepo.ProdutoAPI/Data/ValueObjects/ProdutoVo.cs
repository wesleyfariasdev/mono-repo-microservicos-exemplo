namespace MonoRepo.ProdutoAPI.Data.ValueObjects;

public class ProdutoVo
{
    public static ProdutoVo Empty => new ProdutoVo();
    public static List<ProdutoVo> EmptyList => new List<ProdutoVo>();

    public int? Id { get; set; }
    public string? NomeProduto { get; set; }
    public decimal Preco { get; set; }
    public string? Descricao { get; set; }
    public string? NomeCategoria { get; set; }
    public string? ImagemUrl { get; set; }
}
