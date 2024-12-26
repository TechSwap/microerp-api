using MicroErp.Domain.Entity.OrdemServicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class DetalhesOrdemServicoConfiguration: IEntityTypeConfiguration<DetalhesOrdemServico>
{

    public void Configure(EntityTypeBuilder<DetalhesOrdemServico> builder)
    {
        builder.ToTable("DetalhesOrdemServicos");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("IdDetalhesOrdemServico")
            .IsRequired();

        builder.Property(x => x.OrdemServicoId)
            .HasColumnName("OrdemServicoId")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao");
        
        builder.Property(x => x.Unidade)
            .HasColumnName("Unidade");

        builder.Property(x => x.ValorUnitario)
            .HasColumnName("ValorUnitario");
        
        builder.Property(x => x.Quantidade)
            .HasColumnName("Quantidade");
        
        builder.Property(x => x.PrazoEntrega)
            .HasColumnName("PrazoEntrega");
        
        builder.Property(x => x.Status)
            .HasColumnName("Status");
    }
}