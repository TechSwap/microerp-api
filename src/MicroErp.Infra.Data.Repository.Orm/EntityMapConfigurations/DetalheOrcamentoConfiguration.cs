using MicroErp.Domain.Entity.Orcamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class DetalheOrcamentoConfiguration: IEntityTypeConfiguration<DetalheOrcamento>
{
    public void Configure(EntityTypeBuilder<DetalheOrcamento> builder)
    {
        builder.ToTable("DetalheOrcamentos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdDetalheOrcamento")
            .IsRequired();
        builder.Property(x => x.IdOrcamento)
            .HasColumnName("IdOrcamento")
            .IsRequired();
        builder.Property(x => x.Itm)
            .HasColumnName("Itm")
            .IsRequired();
        builder.Property(x => x.Codigo)
            .HasColumnName("Codigo")
            .IsRequired();
        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .IsRequired();
        builder.Property(x => x.Quantidade)
            .HasColumnName("Quantidade")
            .IsRequired();
        builder.Property(x => x.Unidade)
            .HasColumnName("Unidade")
            .IsRequired();
        builder.Property(x => x.Preco)
            .HasColumnName("Preco")
            .IsRequired();
        builder.Property(x => x.SubTotal)
            .HasColumnName("SubTotal");
        builder.Property(x => x.Total)
            .HasColumnName("Total")
            .IsRequired();
    }
}