using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MonoRepo.ProdutoAPI.Models;

namespace MonoRepo.ProdutoAPI.Context.ConfigEntity;

internal class ProdutoConfigEntity : IEntityTypeConfiguration<Produto>
{
    void IEntityTypeConfiguration<Produto>.Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).HasColumnName("DT_CRIACAO");
        builder.Property(x => x.UpdatedAt).HasColumnName("DT_ATUALIZACAO");

        builder.Property(x => x.NomeProduto)
            .HasColumnName("NOME_PRODUTO")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Preco)
            .HasPrecision(18, 2)
            .HasColumnName("PRECO")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnName("DESCRICAO")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.NomeCategoria)
            .HasColumnName("NOME_CATEGORIA")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ImagemUrl)
            .HasColumnName("IMAGEM_URL")
            .HasMaxLength(500)
            .IsRequired(false);
    }
}
