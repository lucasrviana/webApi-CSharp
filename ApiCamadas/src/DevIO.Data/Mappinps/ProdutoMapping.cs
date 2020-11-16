using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappinps
{
    class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(colunas => colunas.Id);
            builder.Property(colunas => colunas.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(colunas => colunas.Descricao)
               .IsRequired()
               .HasColumnType("varchar(1000)");

            builder.Property(colunas => colunas.Imagem)
               .IsRequired()
               .HasColumnType("varchar(1000)");

            builder.ToTable("Produtos");
        }
    }
}
