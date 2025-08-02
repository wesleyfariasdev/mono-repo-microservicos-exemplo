namespace MonoRepo.Shared.Data.ValueObjects;

public class ProdutoVo : BaseVo<ProdutoVo>
{
    public int? Id { get; set; }
    public string? NomeProduto { get; set; }
    public decimal Preco { get; set; }
    public string? Descricao { get; set; }
    public string? NomeCategoria { get; set; }
    public string? ImagemUrl { get; set; }
}
