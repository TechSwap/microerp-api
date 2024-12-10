using MicroErp.Domain.Entity.OrdemProducao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class DetalheOrdemProducaoConfiguration: IEntityTypeConfiguration<DetalhesOrdemProducao>
{
    public void Configure(EntityTypeBuilder<DetalhesOrdemProducao> builder)
    {
        builder.ToTable("DetalhesOrdemProducao");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdDetalhesOrdemProducao")
            .IsRequired();
        
        builder.Property(x => x.IdOrdemProducao)
            .HasColumnName("IdOrdemProducao")
            .IsRequired();
        
        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .IsRequired();
        
        builder.Property(x => x.Quantidade)
            .HasColumnName("Quantidade");
        
        builder.Property(x => x.Unidade)
            .HasColumnName("Unidade");
        
        builder.Property(x => x.PrazoEntrega)
            .HasColumnName("PrazoEntrega")
            .IsRequired();
        
        builder.Property(x => x.DataEntrega)
            .HasColumnName("DataEntrega");
        
        builder.Property(x => x.DataInicializacao)
            .HasColumnName("DataInicializacao");
        
        builder.Property(x => x.DataFinalizacao)
            .HasColumnName("DataFinalizacao");
        
        builder.Property(x => x.IdFuncionario)
            .HasColumnName("IdFuncionario");
        
        builder.Property(x => x.IdMaquina)
            .HasColumnName("IdMaquina");
        
        builder.Property(x => x.HorasTrabalhadas)
            .HasColumnName("HorasTrabalhadas");
        builder.Property(x => x.Status)
            .HasColumnName("Status");
    }
}
