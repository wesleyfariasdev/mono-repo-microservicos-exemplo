using Microsoft.AspNetCore.Mvc;
using MonoRepo.ProdutoAPI.Data.ValueObjects;
using MonoRepo.ProdutoAPI.Repository.IRepository;

namespace MonoRepo.ProdutoAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController(IProdutoRepository produtoRepository) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> ObterTodosProdutos()
    {
        var produtos = await produtoRepository.ObterTodosProdutos();
        if (produtos == null || produtos.Count == 0)
            return NotFound("Nenhum produto encontrado.");

        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterProdutoPorId(int id)
    {
        var produto = await produtoRepository.ObterProdutoPorId(id);
        if (produto == null)
            return NotFound($"Produto com ID {id} não encontrado.");
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> CriarProduto([FromBody] ProdutoVo produto)
    {
        if (produto == null)
            return BadRequest("Produto não pode ser nulo.");
        var novoProduto = await produtoRepository.CriarProduto(produto);
        return Ok(novoProduto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarProduto(int id, [FromBody] ProdutoVo produto)
    {
        if (produto == null)
            return BadRequest("Produto não pode ser nulo.");
        var produtoAtualizado = await produtoRepository.AtualizarProduto(id, produto);
        if (produtoAtualizado == null)
            return NotFound($"Produto com ID {id} não encontrado.");
        return Ok(produtoAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarProduto(int id)
    {
        var produtoDeletado = await produtoRepository.DeletarProduto(id);
        if (!produtoDeletado)
            return NotFound($"Produto com ID {id} não encontrado.");
        return NoContent();
    }
}
