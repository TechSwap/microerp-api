using MicroErp.Domain.Entity.Departamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class DepartamentoConfiguration: IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamentos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdDepartamento")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .IsRequired();
        builder.Property(x => x.Responsavel)
            .HasColumnName("Responsavel")
            .IsRequired();
        builder.Property(x => x.CentroCusto)
            .HasColumnName("CentroCusto");
          
        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .IsRequired();
        
        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();
    }
}