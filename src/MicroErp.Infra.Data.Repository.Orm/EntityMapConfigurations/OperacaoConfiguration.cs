using MicroErp.Domain.Entity.Operacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class OperacaoConfiguration: IEntityTypeConfiguration<Operacao>
{
    public void Configure(EntityTypeBuilder<Operacao> builder)
    {
        builder.ToTable("Operacoes");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdOperacao")
            .IsRequired();
        
        builder.Property(x => x.IdDepartamento)
            .HasColumnName("IdDepartamento")
            .IsRequired();
        
        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .IsRequired();
        
        builder.Property(x => x.Ativo)
            .HasColumnName("Ativo")
            .IsRequired();
        
        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();
        
        builder.Property(x => x.DataAtualizacao)
            .HasColumnName("DataAtualizacao");
    }
}