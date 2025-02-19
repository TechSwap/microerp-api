using MicroErp.Domain.Entity.Clientes;
using MicroErp.Domain.Entity.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdCliente")
            .IsRequired();

        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .IsRequired();

        builder.Property(x => x.Cnpj)
            .HasColumnName("Cnpj")
            .IsRequired();
        
        builder.Property(x => x.Responsavel)
            .HasColumnName("Responsavel");
        
        builder.Property(x => x.Fantasia)
            .HasColumnName("Fantasia");

        builder.Property(x => x.InscricaoEstadual)
            .HasColumnName("InscricaoEstadual");

        builder.Property(x => x.Contato1)
            .HasColumnName("Contato1");

        builder.Property(x => x.Contato2)
            .HasColumnName("Contato2");

        builder.Property(x => x.Email)
            .HasColumnName("Email");

        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();

        builder.Property(x => x.DataAtualizacao)
            .HasColumnName("DataAtualizacao");

        builder.Property(x => x.Ativo)
            .HasColumnName("Ativo")
            .IsRequired();
    }
}