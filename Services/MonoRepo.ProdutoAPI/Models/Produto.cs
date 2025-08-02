using MonoRepo.ProdutoAPI.Models.Base;

namespace MonoRepo.ProdutoAPI.Models;

internal class Produto : BaseEntity
{
    public Produto(string? nomeProduto, decimal preco, string? descricao, string? nomeCategoria)
    {
        NomeProduto = nomeProduto;
        Preco = preco;
        Descricao = descricao;
        NomeCategoria = nomeCategoria;
        CreatedAt = DateTime.UtcNow;
    }

    public void AtualizarProduto(string? nomeProduto, decimal preco, string? descricao, string? nomeCategoria)
    {
        NomeProduto = nomeProduto;
        Preco = preco;
        Descricao = descricao;
        NomeCategoria = nomeCategoria;
        UpdatedAt = DateTime.UtcNow;
    }

    public Produto(string? nomeProduto, decimal preco, string? descricao, string? nomeCategoria, string? imagemUrl)
    {
        NomeProduto = nomeProduto;
        Preco = preco;
        Descricao = descricao;
        NomeCategoria = nomeCategoria;
        ImagemUrl = imagemUrl;
        CreatedAt = DateTime.UtcNow;
    }

    public string? NomeProduto { get; private set; }
    public decimal Preco { get; private set; }
    public string? Descricao { get; private set; }
    public string? NomeCategoria { get; private set; }
    public string? ImagemUrl { get; private set; }
}