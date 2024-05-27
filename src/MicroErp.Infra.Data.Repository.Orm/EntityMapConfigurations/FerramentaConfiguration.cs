using MicroErp.Domain.Entity.Ferramentas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class FerramentaConfiguration : IEntityTypeConfiguration<Ferramenta>
{
    public void Configure(EntityTypeBuilder<Ferramenta> builder)
    {
        builder.ToTable("Ferramentas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdFerramenta")
            .IsRequired();

        builder.Property(x => x.Codigo)
          .HasColumnName("Codigo");

        builder.Property(x => x.Descricao)
           .HasColumnName("Descricao");

        builder.Property(x => x.ValorCompra)
           .HasColumnName("ValorCompra");

        builder.Property(x => x.Medida)
           .HasColumnName("Medida");

        builder.Property(x => x.FabricanteId)
           .HasColumnName("FabricanteId");

        builder.Property(x => x.CodigoFabricante)
           .HasColumnName("CodigoFabricante");

        builder.Property(x => x.DataCadastro)
          .HasColumnName("DataCadastro")
          .IsRequired();
    }
}
