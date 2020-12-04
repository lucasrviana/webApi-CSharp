using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Api.Controllers
{
    [Route("api/[controller]")]
    public class FornecedoresController : MainController
    {
        private readonly IFornecedor _Fornecedorcontext;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedoresController(INotificador notificador, IFornecedor fornecedorcontext, IMapper mapper, IFornecedorService fornecedorService = null)
            : base(notificador)
        {
            _Fornecedorcontext = fornecedorcontext;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> ObterTodos()
        {
            var lista = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _Fornecedorcontext.ObterTodos());
            return Ok(lista);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> ObterFornecedor(Guid id)
        {
            var fornecedor = await ObterFornecedorProdutosEndereco(id);
            if (fornecedor == null)
                return NotFound();

            return fornecedor;
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorViewModel>> AdcionarFornecedor(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            //var result = 
            await _fornecedorService.Adicionar(fornecedorViewModel);
            //if (!result) return BadRequest();
            return CustomResponse(fornecedorViewModel)
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> AtualizarFornecedor(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (fornecedorViewModel.Id != id)
                return Conflict();

            if (!ModelState.IsValid) return UnprocessableEntity();

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            var result = await _fornecedorService.Atualizar(fornecedor);

            if (!result) return BadRequest();

            return Ok(fornecedorViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> removerFornecedor(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if (fornecedor == null)
                return NotFound();

            var result = await _fornecedorService.Remover(id);

            if (!result) return BadRequest();

            return Ok(fornecedor);
        }
        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _Fornecedorcontext.ObterFornecedorProdutosEndereco(id));
        }

        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _Fornecedorcontext.ObterFornecedorEndereco(id));
        }
    }
}
