using MicroErp.Domain.Entity.Fabricantes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class FabricanteConfiguration : IEntityTypeConfiguration<Fabricante>
{
    public void Configure(EntityTypeBuilder<Fabricante> builder)
    {
        builder.ToTable("Fabricantes");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdFabricante")
            .IsRequired();

        builder.Property(x => x.Descricao)
          .HasColumnName("Descricao")
           .IsRequired();

        builder.Property(x => x.DataCadastro)
         .HasColumnName("DataCadastro")
          .IsRequired();
    }
}
