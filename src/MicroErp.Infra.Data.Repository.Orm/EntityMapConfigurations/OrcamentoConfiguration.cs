using MicroErp.Domain.Entity.Orcamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class OrcamentoConfiguration : IEntityTypeConfiguration<Orcamento>
{

    public void Configure(EntityTypeBuilder<Orcamento> builder)
    {
        builder.ToTable("Orcamentos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdOrcamento")
            .IsRequired();
        
        builder.Property(x => x.Numero)
            .HasColumnName("Numero")
            .IsRequired();
        
          builder.Property(x => x.IdCliente)
                    .HasColumnName("IdCliente")
                    .IsRequired();
          
            builder.Property(x => x.DataEmissao)
                      .HasColumnName("DataEmissao")
                      .IsRequired();
            
            builder.Property(x => x.SubTotal)
                .HasColumnName("SubTotal")
                .IsRequired();
            
            builder.Property(x => x.Desconto)
                .HasColumnName("Desconto")
                .IsRequired();
            
            builder.Property(x => x.Frete)
                .HasColumnName("Frete")
                .IsRequired();
            
            builder.Property(x => x.Total)
                .HasColumnName("Total")
                .IsRequired();
            
            builder.Property(x => x.Observacao)
                .HasColumnName("Observacao");
    }
}