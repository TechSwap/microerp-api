using MicroErp.Domain.Entity.Enderecos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("Enderecos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdEndereco")
            .IsRequired();

        builder.Property(x => x.Cep)
            .HasColumnName("Cep");

        builder.Property(x => x.Logradouro)
           .HasColumnName("Logradouro");

        builder.Property(x => x.Numero)
           .HasColumnName("Numero");

        builder.Property(x => x.Bairro)
           .HasColumnName("Bairro");

        builder.Property(x => x.Cidade)
           .HasColumnName("Cidade");

        builder.Property(x => x.Estado)
           .HasColumnName("Estado");
        
        builder.Property(x => x.Complemento)
           .HasColumnName("Complemento");

        builder.Property(x => x.ClienteId)
           .HasColumnName("ClienteId");

        builder.Property(x => x.FornecedorId)
            .HasColumnName("FornecedorId");

        builder.Property(x => x.UserId)
           .HasColumnName("UserId");
        
         builder.Property(x => x.EmpresaId)
               .HasColumnName("EmpresaId");        
        
        builder.Property(x => x.DataCadastro)
           .HasColumnName("DataCadastro")
           .IsRequired();
        builder.Property(x => x.DataAtualizacao)
           .HasColumnName("DataAtualizacao");
    }
}