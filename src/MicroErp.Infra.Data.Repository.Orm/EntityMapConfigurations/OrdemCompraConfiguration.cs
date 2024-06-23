using MicroErp.Domain.Entity.OrdemCompras;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class OrdemCompraConfiguration: IEntityTypeConfiguration<OrdemCompra>
{
    public void Configure(EntityTypeBuilder<OrdemCompra> builder)
    {
        builder.ToTable("OrdemCompras");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdOrdemCompra")
            .IsRequired();
        
        builder.Property(x => x.IdFornecedor)
            .HasColumnName("IdFornecedor")
            .IsRequired();
        
        builder.Property(x => x.Solicitante)
            .HasColumnName("Solicitante")
            .IsRequired();
        
        builder.Property(x => x.DataPedido)
            .HasColumnName("DataPedido")
            .IsRequired();
        
        builder.Property(x => x.NumeroPedido)
            .HasColumnName("NumeroPedido")
            .IsRequired();
        
        builder.Property(x => x.DigitadoPor)
            .HasColumnName("DigitadoPor")
            .IsRequired();
        
        builder.Property(x => x.DataAtualizacao)
            .HasColumnName("DataAtualizacao");

        builder.Property(x => x.ValorTotal)
            .HasColumnName("ValorTotal");

        builder.Property(x => x.IdStatus)
            .HasColumnName("IdStatus");
            
        builder.Property(x => x.Ativo)
            .HasColumnName("Ativo")
            .IsRequired();
    }
}