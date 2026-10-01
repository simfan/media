namespace Medias.Server.Services.Interfaces;

public interface IMovieBarcodeResolver
{
    Task<string?> ResolveMovieTitleAsync(string barcode, CancellationToken cancellationToken = default);
}
