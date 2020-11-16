using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProduto
    {
        public ProdutoRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Produto> ObterProdutoFornecedor(Guid id) =>
            await Db
                .Include(f => f.Fornecedor)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedor() =>
            await Db.Include(f => f.Fornecedor)
                .AsNoTracking()
                .OrderBy(p => p.Nome)
                .ToListAsync();

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId) =>
             await Buscar(p => p.FornecedorId == fornecedorId);


    }
}
