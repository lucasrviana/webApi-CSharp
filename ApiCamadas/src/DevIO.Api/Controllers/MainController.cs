using DevIO.Business.Interfaces;
using DevIO.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace DevIO.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            this._notificador = notificador;
        }

        protected bool OperacaoValida() => !_notificador.TemNotificacao();


        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (modelState.IsValid) NotificarErrorModelInvalida(modelState);
            return CustomResponse();
        }

        private ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
                return Ok(new { success = true, data = result });

            return BadRequest(new { success = false, errors = _notificador.ObteNotificacao().Select(n => n.Mensgem) });

        }

        protected void NotificarErrorModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception is null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string errorMsg)
        {
            _notificador.handle(new Notificacao(errorMsg));
        }
    }
}
