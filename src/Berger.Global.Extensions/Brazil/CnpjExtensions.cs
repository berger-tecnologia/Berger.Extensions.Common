namespace Berger.Global.Extensions.Brazil
{
    public static class CnpjExtensions
    {
        public static bool CheckCnpj(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            int[] multiplier_1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier_2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var rest = 0;
            var total = 0;
            var digit = string.Empty;
            var temporary = string.Empty;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            temporary = cnpj.Substring(0, 12);
            total = 0;
            
            for (int i = 0; i < 12; i++)
                total += int.Parse(temporary[i].ToString()) * multiplier_1[i];

            rest = (total % 11);
            
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            temporary = temporary + digit;
            total = 0;

            for (int i = 0; i < 13; i++)
                total += int.Parse(temporary[i].ToString()) * multiplier_2[i];

            rest = (total % 11);

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return cnpj.EndsWith(digit);
        }
    }
}