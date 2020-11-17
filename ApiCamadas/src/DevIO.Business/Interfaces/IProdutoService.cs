using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{

    public interface IProdutoService
    {
        Task Adicionar(Produto entity);

        Task Atualizar(Produto entity);

        Task Remover(Guid id);
    }
}
