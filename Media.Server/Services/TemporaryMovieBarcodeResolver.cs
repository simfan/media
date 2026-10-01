using Medias.Server.Services.Interfaces;

namespace Medias.Server.Services;

/// <summary>
/// Development-only bridge from a known test barcode to a movie title.
/// Replace this with a UPC/EAN provider before using it for a real catalog.
/// </summary>
public sealed class TemporaryMovieBarcodeResolver(IConfiguration configuration) : IMovieBarcodeResolver
{
    private readonly IReadOnlyDictionary<string, string> _mappings =
        configuration.GetSection("TemporaryMovieBarcodeMappings")
            .Get<Dictionary<string, string>>()
            ?? new Dictionary<string, string>();

    public Task<string?> ResolveMovieTitleAsync(string barcode, CancellationToken cancellationToken = default)
    {
        var normalizedBarcode = new string(barcode.Where(char.IsDigit).ToArray());

        return Task.FromResult(
            _mappings.TryGetValue(normalizedBarcode, out var title)
                ? title
                : null);
    }
}
