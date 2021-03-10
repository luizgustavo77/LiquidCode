using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseConfiguration(new ConfigurationBuilder()
                  .AddCommandLine(args)
                  .Build())
              .UseStartup<Startup>()
              //.UseUrls("http://localhost:5002")
              .Build();
    }
}
