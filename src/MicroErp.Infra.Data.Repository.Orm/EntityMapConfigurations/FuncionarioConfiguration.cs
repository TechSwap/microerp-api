using MicroErp.Domain.Entity.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class FuncionarioConfiguration: IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("Funcionarios");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdFuncionario")
            .IsRequired();
        
        builder.Property(x => x.Codigo)
            .HasColumnName("Codigo")
            .IsRequired();
        
        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .IsRequired();
        
        builder.Property(x => x.DepartamentoId)
            .HasColumnName("DepartamentoId");

        builder.Property(x => x.CentroCusto)
            .HasColumnName("CentroCusto");

        builder.Property(x => x.Funcao)
            .HasColumnName("Funcao");
           
        builder.Property(x => x.ValorHora)
            .HasColumnName("ValorHora")
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

