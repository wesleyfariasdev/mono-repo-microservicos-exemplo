using MonoRepo.Shared.Data.ValueObjects;
using MonoRepo.Web.Services.IServices;

namespace MonoRepo.Web.Services;

public class ProdutoServices(HttpClient client) : IProductServices
{
    public const string ProdutoApiPath = "api/produto";
    public async Task<ProdutoVo> AtualizarProduto(int id, ProdutoVo produto)
    {
        var produtoRequest = await client.PutAsJsonAsync($"{ProdutoApiPath}/{id}", produto);
        if (produtoRequest.IsSuccessStatusCode)
            return await produtoRequest.Content.ReadFromJsonAsync<ProdutoVo>();
        throw new Exception("Não foi possível atualizar o produto");
    }

    public async Task<ProdutoVo> CriarProduto(ProdutoVo produto)
    {
        var produtoRequest = await client.PostAsJsonAsync(ProdutoApiPath, produto);
        if (produtoRequest.IsSuccessStatusCode)
            return await produtoRequest.Content.ReadFromJsonAsync<ProdutoVo>();
        throw new Exception("Não foi possível criar o produto.");
    }

    public async Task<bool> DeletarProduto(int id)
    {
        var produtoRequest = await client.DeleteAsync($"{ProdutoApiPath}/{id}");
        if (produtoRequest.IsSuccessStatusCode)
            return await produtoRequest.Content.ReadFromJsonAsync<bool>();
        throw new Exception($"Não foi possível deletar o produto com ID {id}.");
    }

    public async Task<ProdutoVo> ObterProdutoPorId(int id)
    {
        var produtoRequest = await client.GetAsync($"{ProdutoApiPath}/{id}");
        if (produtoRequest.IsSuccessStatusCode)
            return await produtoRequest.Content.ReadFromJsonAsync<ProdutoVo>();
        throw new Exception($"Produto com ID {id} não encontrado.");
    }

    public async Task<List<ProdutoVo>> ObterTodosProdutos()
    {
        var produtosRequest = await client.GetAsync(ProdutoApiPath);
        if (produtosRequest.IsSuccessStatusCode)
            return await produtosRequest.Content.ReadFromJsonAsync<List<ProdutoVo>>();
        throw new Exception("Nenhum produto encontrado.");
    }
}
