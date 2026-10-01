namespace Medias.Shared.DTOs;

public sealed class MovieBarcodeLookupDto
{
    public string Barcode { get; init; } = string.Empty;
    public string SearchTitle { get; init; } = string.Empty;
    public List<TMDbMovieSearchRecord> Results { get; init; } = [];
}
