using System.Collections.Generic;

namespace Berger.Global.Extensions.Brazil
{
    public static class CpfExtensions
    {
        public static bool CheckCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;
            string dgsVerificadores;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            var invalids = new List<string>();

            invalids.Add("00000000000");
            invalids.Add("11111111111");
            invalids.Add("22222222222");
            invalids.Add("33333333333");
            invalids.Add("44444444444");
            invalids.Add("55555555555");
            invalids.Add("66666666666");
            invalids.Add("77777777777");
            invalids.Add("88888888888");
            invalids.Add("99999999999");

            if(invalids.Contains(cpf))
                return false;
        
            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            dgsVerificadores = digito;
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            dgsVerificadores += digito;

            if ((dgsVerificadores) == cpf.Remove(0, 9))
                return true;

            else
                return false;
        }
    }
}