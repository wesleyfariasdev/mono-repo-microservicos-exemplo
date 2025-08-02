using Microsoft.EntityFrameworkCore;
using MonoRepo.ProdutoAPI.Context;
using MonoRepo.ProdutoAPI.Data.ValueObjects;
using MonoRepo.ProdutoAPI.Models;
using MonoRepo.ProdutoAPI.Repository.IRepository;

namespace MonoRepo.ProdutoAPI.Repository;

internal class ProdutoRepository(ProdutoContextDb produtoDb) : IProdutoRepository
{
    public async Task<ProdutoVo> AtualizarProduto(int id, ProdutoVo produto)
    {
        var obterProduto = await produtoDb.Produtos.Where(p => p.Id == id).FirstOrDefaultAsync();

        if (obterProduto == null)
            throw new ArgumentException("Não foi possível atualizar o produto");

        obterProduto.AtualizarProduto(produto.NomeProduto,
                                      produto.Preco,
                                      produto.Descricao,
                                      produto.NomeCategoria);
        await produtoDb.SaveChangesAsync();

        return new ProdutoVo
        {
            Id = obterProduto.Id,
            NomeProduto = obterProduto.NomeProduto,
            Preco = obterProduto.Preco,
            Descricao = obterProduto.Descricao,
            NomeCategoria = obterProduto.NomeCategoria,
            ImagemUrl = obterProduto.ImagemUrl
        };
    }

    public async Task<ProdutoVo> CriarProduto(ProdutoVo produto)
    {
        var produtoEntity = new Produto(produto.NomeProduto,
                                        produto.Preco,
                                        produto.Descricao,
                                        produto.NomeCategoria,
                                        produto.ImagemUrl);

        await produtoDb.Produtos.AddAsync(produtoEntity);
        await produtoDb.SaveChangesAsync();

        if (produtoEntity.Id <= 0)
            throw new ArgumentException("Não foi possível criar o produto");

        return new ProdutoVo
        {
            Id = produtoEntity.Id,
            NomeProduto = produtoEntity.NomeProduto,
            Preco = produtoEntity.Preco,
            Descricao = produtoEntity.Descricao,
            NomeCategoria = produtoEntity.NomeCategoria,
            ImagemUrl = produtoEntity.ImagemUrl
        };
    }

    public async Task<bool> DeletarProduto(int id)
    {
        var produto = produtoDb.Produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null)
            throw new ArgumentException("Não foi possível deletar o produto");

        produtoDb.Produtos.Remove(produto);
        await produtoDb.SaveChangesAsync();
        return true;
    }

    public async Task<ProdutoVo> ObterProdutoPorId(int id) =>
           await produtoDb.Produtos.Where(p => p.Id == id)
            .Select(p => new ProdutoVo
            {
                Id = p.Id,
                NomeProduto = p.NomeProduto,
                Preco = p.Preco,
                Descricao = p.Descricao,
                NomeCategoria = p.NomeCategoria,
                ImagemUrl = p.ImagemUrl
            })
            .FirstOrDefaultAsync() ?? ProdutoVo.Empty;

    public async Task<List<ProdutoVo>> ObterTodosProdutos() =>
           await produtoDb.Produtos
            .Select(p => new ProdutoVo
            {
                Id = p.Id,
                NomeProduto = p.NomeProduto,
                Preco = p.Preco,
                Descricao = p.Descricao,
                NomeCategoria = p.NomeCategoria,
                ImagemUrl = p.ImagemUrl
            })
            .ToListAsync() ?? ProdutoVo.EmptyList;
}
