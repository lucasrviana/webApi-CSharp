using System.Linq;

namespace DevIO.Business.Notifications
{
    public class Notificacao
    {
        public string Mensgem { get; }

        public Notificacao(string mensagem) => Mensgem = mensagem;
    }
}
