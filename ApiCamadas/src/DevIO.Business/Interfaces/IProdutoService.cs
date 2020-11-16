using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IFornecedorService
    {
        Task Adicionar(Fornecedor entity);

        Task Atualizar(Fornecedor entity);

        Task Atualizarendereco(Fornecedor entity);

        Task Remover(Guid id);
    }

    public interface IProdutoService
    {
        Task Adicionar(Produto entity);

        Task Atualizar(Produto entity);

        Task Remover(Guid id);
    }
}
