using Microsoft.AspNetCore.Http;

namespace LiquidCode.Helpers
{
    public static class Session
    {
        private static IHttpContextAccessor _accessor = new HttpContextAccessor();
        
        public static void Create<T>(string key, T objeto)
        {
            string jsonValue = new Serializer().SetObject<T>(objeto);
            _accessor.HttpContext.Session.SetString(key, jsonValue);
        }

        public static T GetObject<T>(string key)
        {
            string json = null;
            if (!string.IsNullOrWhiteSpace(key))
                json = _accessor.HttpContext.Session.GetString(key);
            if (string.IsNullOrWhiteSpace(json))
                return default(T);
            return new Serializer().GetObject<T>(json);
        }

        public static void CleanObject()
        {
            _accessor.HttpContext.Session.Clear();
        }
    }
}
