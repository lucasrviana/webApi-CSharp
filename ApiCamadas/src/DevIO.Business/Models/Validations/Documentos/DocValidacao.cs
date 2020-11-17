using System;
using System.Collections.Generic;
using System.Linq;

namespace DevIO.Business.Models.Validations.documentos
{
    public class DocValidacao
    {
        public static int _Tamanho;

        public static bool Validar(string doc, TipoFornecedor tipo)
        {
            _Tamanho = (int)((tipo == TipoFornecedor.PessoaFisica) ? QuantidadeDoc.cpf : QuantidadeDoc.cnpj);
            var DocNumero = Util.ApenasNumero(doc);
            if (!TamanhoValido(DocNumero)) return false;
            return !TemDigitosRepitidos(DocNumero) && TemDigitosValidos(DocNumero);
        }

        private static bool TemDigitosRepitidos(string cpfNumero)
        {
            List<string> docs = new List<string>();

            for (var i = 0; i <= 9; i++)
            {
                string doc = "";
                for (var j = 0; j <= _Tamanho; j++)
                    doc += i.ToString();

                docs.Add (doc);
            }

            return docs.Contains(cpfNumero);
        }

        private static bool TemDigitosValidos(string valor)
        {
            var inicioDigito = _Tamanho - 2;
            var number = valor.Substring(0, inicioDigito);
            var digitoVerificador = new DigitoVerificador(number)
                .ComMuliplicadoresDeAte(2, _Tamanho)
                .Substituindo("0", 10, 11);
            var firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            var SecondDigit = digitoVerificador.CalculaDigito();

            return string.Concat(firstDigit, SecondDigit) == valor.Substring(inicioDigito, 2);
        }

        private static bool TamanhoValido(string valor) => valor.Length == _Tamanho;
    }
}
