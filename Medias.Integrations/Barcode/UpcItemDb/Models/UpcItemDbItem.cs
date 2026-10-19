namespace Medias.Integrations.Barcode.UpcItemDb.Models;

public class UpcItemDbItem
{
    public string? Ean { get; set; }

    public string? Upc { get; set; }

    public string? Gtin { get; set; }

    public string? Asin { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public string? Dimension { get; set; }

    public string? Weight { get; set; }

    public string? Category { get; set; }

    public string? Currency { get; set; }

    public decimal? LowestRecordedPrice { get; set; }

    public decimal? HighestRecordedPrice { get; set; }

    public List<string> Images { get; set; } = [];
}