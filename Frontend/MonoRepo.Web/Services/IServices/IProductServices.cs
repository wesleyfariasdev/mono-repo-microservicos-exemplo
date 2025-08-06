using MonoRepo.Shared.Data.ValueObjects;

namespace MonoRepo.Web.Services.IServices;

public interface IProductServices
{
    Task<ProdutoVo> ObterProdutoPorId(int id);
    Task<List<ProdutoVo>> ObterTodosProdutos();
    Task<ProdutoVo> CriarProduto(ProdutoVo produto);
    Task<ProdutoVo> AtualizarProduto(ProdutoVo produto);
    Task<bool> DeletarProduto(int id);
}
