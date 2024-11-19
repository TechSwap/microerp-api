using MicroErp.Domain.Entity.Maquinas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroErp.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class MaquinaConfiguration: IEntityTypeConfiguration<Maquina>
{
    public void Configure(EntityTypeBuilder<Maquina> builder)
    {
        builder.ToTable("Maquinas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdMaquina")
            .IsRequired();
        builder.Property(x => x.NumeroSerie)
            .HasColumnName("NumeroSerie")
            .IsRequired();
        builder.Property(x => x.Fabricante)
            .HasColumnName("Fabricante");

        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao");

        builder.Property(x => x.IdDepartamento)
            .HasColumnName("IdDepartamento");
        
        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .IsRequired();
        
        builder.Property(x => x.Vendida)
            .HasColumnName("Vendida");

        builder.Property(x => x.AtivoFixo)
            .HasColumnName("AtivoFixo");
        
        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();

        builder.Property(x => x.DataAtualizacao)
            .HasColumnName("DataAtualizacao");
    }
}