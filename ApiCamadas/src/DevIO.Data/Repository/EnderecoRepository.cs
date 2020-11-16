using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEndereco
    {
        public EnderecoRepository(MeuDbContext context) : base(context)
        {
            
        }

      
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId) => 
            await Db.AsNoTracking()
               .Include(f => f.Fornecedor)
               .FirstOrDefaultAsync(e => e.FornecedorId == fornecedorId);
    }
}
