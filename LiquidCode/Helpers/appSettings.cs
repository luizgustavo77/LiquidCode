using Microsoft.Extensions.Configuration;
using System.IO;

namespace LiquidCode.Helpers
{
    public class appSettings
    {
        public string Get(string key)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            IConfigurationRoot Configuration = builder.Build();
            return Configuration[key];
        }
    }
}
