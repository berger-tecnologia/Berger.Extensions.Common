using System.Collections.Generic;

namespace Berger.Extensions.Common.Brazil
{
    public static class CpfExtension
    {
        public static bool CheckCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            int[] multiplier_1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier_2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var rest = 0;
            var total = 0;

            var digit = string.Empty;
            var temporary = string.Empty;
            var verifiers = string.Empty;
            
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

            temporary = cpf.Substring(0, 9);
            total = 0;

            for (int i = 0; i < 9; i++)
                total += int.Parse(temporary[i].ToString()) * multiplier_1[i];

            rest = total % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            verifiers = digit;
            temporary = temporary + digit;
            total = 0;

            for (int i = 0; i < 10; i++)
                total += int.Parse(temporary[i].ToString()) * multiplier_2[i];

            rest = total % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            verifiers += digit;

            if ((verifiers) == cpf.Remove(0, 9))
                return true;
            else
                return false;
        }
    }
}