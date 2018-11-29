using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace KittyDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HighScoreRepo.connectionString =
               JObject.Parse(File.ReadAllText("appsettings.Development.json"))["ConnectionStrings"]["DefaultConnection"].ToString();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
