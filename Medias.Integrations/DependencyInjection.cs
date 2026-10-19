using Medias.Integrations.Barcode;
using Medias.Integrations.Barcode.UpcItemDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Medias.Integrations;

public static class DependencyInjection
{
    public static IServiceCollection AddMediaIntegrations(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddOptions<UpcItemDbOptions>()
            .Bind(configuration.GetSection(UpcItemDbOptions.SectionName));

        services.AddHttpClient<UpcItemDbClient>((serviceProvider, client) =>
        {
            var options = serviceProvider
                .GetRequiredService<IOptions<UpcItemDbOptions>>()
                .Value;

            client.BaseAddress = new Uri(options.BaseUrl);
        });
        services.AddScoped<IBarcodeLookupService, UpcItemDbBarcodeLookupService>();
        return services;
    }
}