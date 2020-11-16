using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class ProdutoService  : BaseService, IProdutoService
    {
        public ProdutoService(INotificador notificador) : base(notificador)
        {
        }

        public Task Adicionar(Produto entity)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Produto entity)
        {
            throw new NotImplementedException();
        }


        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
