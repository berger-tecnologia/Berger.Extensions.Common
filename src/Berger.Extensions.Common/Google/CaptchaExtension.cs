using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Berger.Extensions.Common.Google
{
    public static class CaptchaExtension
    {
        public static bool Check(string secret, string response)
        {
            var httpClient = new HttpClient();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("secret", secret),
                new KeyValuePair<string, string>("response", response)});

            var result = httpClient.PostAsync($"https://www.google.com/recaptcha/api/siteverify", content).Result;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                string retorno = result.Content.ReadAsStringAsync().Result;
                
                dynamic confirmation = JObject.Parse(retorno);

                if (confirmation.success != true)
                    return false;

                return true;
            }
            else
                return false;
        }
    }
}