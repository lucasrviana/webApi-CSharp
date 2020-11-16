using DevIO.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObteNotificacao();
        void handle(Notificacao notificacao);
    }
}
