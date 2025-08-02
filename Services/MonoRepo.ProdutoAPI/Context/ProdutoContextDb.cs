using Microsoft.EntityFrameworkCore;
using MonoRepo.ProdutoAPI.Models;

namespace MonoRepo.ProdutoAPI.Context;

internal class ProdutoContextDb : DbContext
{
    public ProdutoContextDb(DbContextOptions<ProdutoContextDb> options) : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoContextDb).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}