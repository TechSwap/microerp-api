using MicroErp.Domain.Entity.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("Empresa");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("EmpresaId");  
        builder.Property(x => x.NomeFantasia)
            .HasColumnName("NomeFantasia");     
        builder.Property(x => x.RazaoSocial)
            .HasColumnName("RazaoSocial");
        builder.Property(x => x.Cnpj)
            .HasColumnName("Cnpj");           
        builder.Property(x => x.InscricaoEstadual)
            .HasColumnName("InscricaoEstadual");
        builder.Property(x => x.Contato1)
            .HasColumnName("Contato1"); 
        builder.Property(x => x.Email)
            .HasColumnName("Email");
         builder.Property(x => x.Responsavel)
            .HasColumnName("Responsavel");
          builder.Property(x => x.DataFundacao)
             .HasColumnName("DataFundacao");
          builder.Property(x => x.TipoEmpresa)
             .HasColumnName("TipoEmpresa");
          builder.Property(x => x.Logo)
             .HasColumnName("Logo");
        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();        
    }
}