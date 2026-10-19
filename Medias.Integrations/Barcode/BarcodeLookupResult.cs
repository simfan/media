namespace Medias.Integrations.Barcode;

public class BarcodeLookupResult
{
    public BarcodeLookupStatus Status { get; init; }

    public string Barcode { get; init; } = string.Empty;

    public string? Title { get; init; }

    public string? Description { get; init; }

    public string? Brand { get; init; }

    public string? Category { get; init; }

    public string? ImageUrl { get; init; }
}