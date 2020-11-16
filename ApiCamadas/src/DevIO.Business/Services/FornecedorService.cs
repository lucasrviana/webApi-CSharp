using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedor _fornecedorRep;

        public FornecedorService(IFornecedor fornecedorRep, INotificador notificador) : base(notificador)
        {
            _fornecedorRep = fornecedorRep;
        }

        public async Task Adicionar(Fornecedor entity)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), entity)) return;
            
            if(_fornecedorRep.Buscar(f => f.Documento == entity.Documento).Result.Any())
            {
                Notificar("Ja existe este fornecedor");
                return;
            }

            await _fornecedorRep.Adicionar(entity);

            return;
        }

        public Task Atualizar(Fornecedor entity)
        {
            throw new NotImplementedException();
        }


        public Task Atualizarendereco(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
