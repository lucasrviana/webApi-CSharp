using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedor
    {
        public FornecedorRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id) =>
            await Db.AsNoTracking()
              .Include(e => e.Endereco)
              .FirstOrDefaultAsync(f => f.Id == id);

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id) => await Db.AsNoTracking()
              .Include(e => e.Endereco)
              .Include(p => p.Produtos)
              .FirstOrDefaultAsync(f => f.Id == id);
    }
}
