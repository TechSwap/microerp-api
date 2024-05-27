using MicroErp.Domain.Entity.Fornecedores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class FornecedorConfiguration: IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.ToTable("Fornecedores");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdFornecedor")
            .IsRequired();

        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .IsRequired();

        builder.Property(x => x.Cnpj)
            .HasColumnName("Cnpj")
            .IsRequired();

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