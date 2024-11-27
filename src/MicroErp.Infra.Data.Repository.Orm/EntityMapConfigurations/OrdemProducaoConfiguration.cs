using MicroErp.Domain.Entity.OrdemProducao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class OrdemProducaoConfiguration: IEntityTypeConfiguration<OrdemProducao>
{

    public void Configure(EntityTypeBuilder<OrdemProducao> builder)
    {
        builder.ToTable("OrdemProducao");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdOrdemProducao")
            .IsRequired();
        
        builder.Property(x => x.IdOrdemServico)
            .HasColumnName("IdOrdemServico");
        
        builder.Property(x => x.IdCliente)
            .HasColumnName("IdCliente")
            .IsRequired();
        
        builder.Property(x => x.NumeroOp)
            .HasColumnName("NumeroOp")
            .IsRequired();

        builder.Property(x => x.Prazo)
            .HasColumnName("Prazo");
        
        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .IsRequired();
        
        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();

        builder.Property(x => x.DataAtualizacao)
            .HasColumnName("DataAtualizacao");
    }
}