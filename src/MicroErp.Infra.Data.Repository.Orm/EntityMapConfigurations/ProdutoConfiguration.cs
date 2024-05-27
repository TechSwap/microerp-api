using MicroErp.Domain.Entity.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdProduto")
            .IsRequired();

        builder.Property(x => x.Codigo)
            .HasColumnName("Codigo");

        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .IsRequired();

        builder.Property(x => x.Unidade)
            .HasColumnName("Unidade");

        builder.Property(x => x.PrecoCusto)
            .HasColumnName("PrecoCusto");

        builder.Property(x => x.PrecoVenda)
            .HasColumnName("PrecoVenda");

        builder.Property(x => x.CodigoBarras)
            .HasColumnName("CodigoBarras");

        builder.Property(x => x.FornecedorId)
            .HasColumnName("FornecedorId");

        builder.Property(x => x.ClienteId)
            .HasColumnName("ClienteId");

        builder.Property(x => x.Ativo)
            .HasColumnName("Ativo")
            .IsRequired();

        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();

        builder.Property(x => x.DataAtualizacao)
            .HasColumnName("DataAtualizacao");

        builder.Property(x => x.Observacao)
            .HasColumnName("Observacao");
    }
}
