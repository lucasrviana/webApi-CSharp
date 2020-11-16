using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappinps
{
    class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(colunas => colunas.Id);

            builder.Property(colunas => colunas.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(colunas => colunas.Documento)
               .IsRequired()
               .HasColumnType("varchar(14)");

            builder.HasOne(fornecedor => fornecedor.Endereco)
                .WithOne(endereco => endereco.Fornecedor);

            builder.HasMany(fornecedor => fornecedor.Produtos)
                .WithOne(produto => produto.Fornecedor)
                .HasForeignKey(produto => produto.FornecedorId);

            builder.ToTable("Fornecedores");
        }
    }
}


