using Newtonsoft.Json;

namespace LiquidCode.Helpers
{
    public class Serializer
    {
        public T GetObject<T>(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
                return JsonConvert.DeserializeObject<T>(json);
            return default(T);
        }

        public string SetObject<T>(T objeto)
        {
            if (objeto != null)
                return JsonConvert.SerializeObject(objeto);
            return null;
        }
    }
}
