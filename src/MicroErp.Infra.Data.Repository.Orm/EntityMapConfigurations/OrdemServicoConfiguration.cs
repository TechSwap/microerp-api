using MicroErp.Domain.Entity.OrdemServicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class OrdemServicoConfiguration: IEntityTypeConfiguration<OrdemServico>
{
    public void Configure(EntityTypeBuilder<OrdemServico> builder)
    {
        builder.ToTable("OrdemServicos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdOrdemServico")
            .IsRequired();
        
        builder.Property(x => x.NumeroOS)
            .HasColumnName("NumeroOS")
            .IsRequired();
        
        builder.Property(x => x.IdCliente)
            .HasColumnName("IdCliente")
            .IsRequired();
        
        builder.Property(x => x.Solicitante)
            .HasColumnName("Solicitante")
            .IsRequired();
        
        builder.Property(x => x.NotaEntrada)
            .HasColumnName("NotaEntrada");
        
        builder.Property(x => x.NotaSaida)
            .HasColumnName("NotaSaida");

        builder.Property(x => x.Pedido)
            .HasColumnName("Pedido");

        builder.Property(x => x.Orcamento)
            .HasColumnName("Orcamento");
            
        builder.Property(x => x.ValorTotal)
            .HasColumnName("ValorTotal")
            .IsRequired();
        builder.Property(x => x.Prazo)
            .HasColumnName("Prazo");
           
        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();
        builder.Property(x => x.DataPrevisaoEntrega)
            .HasColumnName("DataPrevisaoEntrega");
           
        builder.Property(x => x.DataEntrega)
            .HasColumnName("DataEntrega");
    }
}