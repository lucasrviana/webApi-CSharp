using System.Collections.Generic;

namespace DevIO.Business.Validations.documentos
{
    internal class DigitoVerificador
    {
        private string _Numero;
        private const int Modulo = 11;
        private readonly IList<int> _multilicadores = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _substrituicoes = new Dictionary<int, string>();
        private bool _complementarDoModulo = true;

        public DigitoVerificador(string number)
        {
            this._Numero = number;
        }

        public DigitoVerificador ComMuliplicadoresDeAte(int primeiroMult, int ultimoMult)
        {
            _multilicadores.Clear();
            for (var i = primeiroMult; i <= ultimoMult; i++)
                _multilicadores.Add(i);
            return this;
        }
        public DigitoVerificador Substituindo(string substituto, params int[] digitos)
        {
            foreach (var i in digitos)
                _substrituicoes[i] = substituto;
            return this;
        }

        public void AddDigito(object digito)
        {
            _Numero = string.Concat(_Numero, digito);
        }

        public object CalculaDigito()
        {
            return !(_Numero.Length > 0) ? "" : GetDigitSum();
        }

        private string GetDigitSum()
        {
            var soma = 0;
            for (int i = _Numero.Length - 1, m = 0; i >= 0; i--)
            {
                var produto = (int)char.GetNumericValue(_Numero[i]) * _multilicadores[m];
                soma += produto;
                if (++m >= _multilicadores.Count) m = 0;
            }
            var mod = (soma % Modulo);
            var resultado = _complementarDoModulo ? Modulo - mod : mod;

            return _substrituicoes.ContainsKey(resultado) ? _substrituicoes[resultado] : resultado.ToString();
        }
    }
}
