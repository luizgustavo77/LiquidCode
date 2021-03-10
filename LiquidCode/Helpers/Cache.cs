using Microsoft.Extensions.Caching.Distributed;

namespace LiquidCode.Helpers
{
    public class Cache
    {
        private readonly IDistributedCache _cache;

        public Cache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public void Create<T>(string key, T objeto)
        {
            string jsonValue = new Serializer().SetObject<T>(objeto);
            _cache.SetString(key, jsonValue);
        }
        public void Create(string key, string value)
        {
            _cache.SetString(key, value);
        }

        public T Get<T>(string key)
        {
            string json = null;
            if (!string.IsNullOrWhiteSpace(key))
                json = _cache.GetString(key);
            return new Serializer().GetObject<T>(json);
        }

        public string Get(string key)
        {
            return _cache.GetString(key);
        }
    }
}
