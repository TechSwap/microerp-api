using MicroErp.Domain.Entity.OrdemCompras;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class DetalhesOrdemCompraConfiguration: IEntityTypeConfiguration<DetalhesOrdemCompra>
{
    public void Configure(EntityTypeBuilder<DetalhesOrdemCompra> builder)
    {
        builder.ToTable("DetalhesOrdemCompras");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdDetalhesOrdemCompra")
            .IsRequired();
        
        builder.Property(x => x.IdOrdemCompra)
            .HasColumnName("IdOrdemCompra")
            .IsRequired();
        
        builder.Property(x => x.Item)
            .HasColumnName("Item")
            .IsRequired();
        
        builder.Property(x => x.Quantidade)
            .HasColumnName("Quantidade")
            .IsRequired();
        
        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .IsRequired();
        
        builder.Property(x => x.Unidade)
            .HasColumnName("Unidade")
            .IsRequired();
        
        builder.Property(x => x.PrecoUnitario)
            .HasColumnName("PrecoUnitario")
            .IsRequired();
        
        builder.Property(x => x.ValorTotal)
            .HasColumnName("ValorTotal")
            .IsRequired();
        
        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();
        
        builder.Property(x => x.DataAtualizacao)
            .HasColumnName("DataAtualizacao");
    }
}