using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TSContaCorrente.Domain.Entidades;
using TSContaCorrente.Infra.Data;
using TSContaCorrente.Infra.Extensions;

namespace TSContaCorrente.Api.Extensions
{
    public static class IHostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                using (var context = services.GetService<AppDbContext>())
                {
                    context.Seed();
                }
            }

            return host;
        }
    }
}
