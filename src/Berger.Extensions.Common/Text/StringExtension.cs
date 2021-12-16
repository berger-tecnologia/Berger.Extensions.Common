using System.Text.RegularExpressions;

namespace Berger.Extensions.Common.Text
{
    public static class StringExtension
    {
        public static string RemoveSpecial(this string text)
        {
            if (!string.IsNullOrEmpty(text))
                return Regex.Replace(text, @"[^\w\d\s]", "");
            else
                return string.Empty;
        }

        public static string RemoveAccents(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                string input = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
                string output = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

                for (int i = 0; i < input.Length; i++)
                    text = text.Replace(input[i].ToString(), output[i].ToString());

                return text;
            }
            else
                return string.Empty;
        }
    }
}