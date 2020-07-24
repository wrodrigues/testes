using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TSContaCorrente.Api.Extensions;

namespace TSContaCorrente.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            host.SeedData();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
