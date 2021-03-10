using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LiquidCode.Helpers
{
    public class Coockie : Controller
    {
        public void Create(string key, string value, int expireHours)
        {
            var option = new CookieOptions();
            option.Expires = DateTime.Now.AddHours(expireHours);
            Response.Cookies.Append(key, value, option);
        }
        public string GetValue(string key)
        {
            return Request.Cookies[key];
        }
    }
}
