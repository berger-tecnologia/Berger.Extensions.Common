using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Berger.Extensions.Common.Json
{
    public static class JsonExtension
    {
        public static string Serialize<T>(this T obj) => JsonConvert.SerializeObject(obj);
        public static T Deserialize<T>(this string json) => JsonConvert.DeserializeObject<T>(json);
        public static void ConfigureLoopHandling()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }
        public static void ConfigureFormatting(Formatting format)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = format
            };
        }
        public static void ConfigureDateFormat(string format)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                DateFormatString = format
            };
        }
        public static void ConfigureContract(string format)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
            };
        }
    }
}