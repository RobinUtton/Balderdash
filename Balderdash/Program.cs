using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

[assembly: CLSCompliant(false)]
namespace Balderdash
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://0.0.0.0:5000;https://0.0.0.0:5001");
                });
    }
}
