using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappinps
{
    class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(colunas => colunas.Id);

            builder.Property(colunas => colunas.Logradouro)
            .IsRequired()
            .HasColumnType("varchar(200)");

            builder.Property(colunas => colunas.Numero)
            .IsRequired()
            .HasColumnType("varchar(50)");

            builder.Property(colunas => colunas.Cep)
            .IsRequired()
            .HasColumnType("varchar(8)");

            builder.Property(colunas => colunas.Complemento)
            .IsRequired()
            .HasColumnType("varchar(250)");

            builder.Property(colunas => colunas.Bairro)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(colunas => colunas.Cidade)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(colunas => colunas.Estado)
           .IsRequired()
           .HasColumnType("varchar(50)");

            builder.ToTable("Enderecos");
        }
    }
}
