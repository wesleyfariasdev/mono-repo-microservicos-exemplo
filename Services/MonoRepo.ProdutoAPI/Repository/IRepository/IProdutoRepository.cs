
using MonoRepo.Shared.Data.ValueObjects;

namespace MonoRepo.ProdutoAPI.Repository.IRepository;

public interface IProdutoRepository
{
    Task<ProdutoVo> ObterProdutoPorId(int id);
    Task<List<ProdutoVo>> ObterTodosProdutos();
    Task<ProdutoVo> CriarProduto(ProdutoVo produto);
    Task<ProdutoVo> AtualizarProduto(int id, ProdutoVo produto);
    Task<bool> DeletarProduto(int id);
}
