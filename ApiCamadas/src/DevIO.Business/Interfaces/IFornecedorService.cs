using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IFornecedorService
    {
        Task<bool> Adicionar(Fornecedor entity);

        Task<bool> Atualizar(Fornecedor entity);

        Task AtualizarEndereco(Endereco entity);

        Task<bool> Remover(Guid id);
    }
}
