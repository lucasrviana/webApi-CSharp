namespace DevIO.Business.Validations.documentos
{
    public class Util
    {
        internal static string ApenasNumero(string valor)
        {
            var onlyNumber = "";
            foreach (var s in valor)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}
