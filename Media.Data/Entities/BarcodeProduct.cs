using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Entities
{
    public class BarcodeProduct
    {
        public int Id { get; set; }
        public string Barcode { get; init; } = string.Empty;

        public string? Title { get; init; }

        public string? Description { get; init; }

        public string? Brand { get; init; }

        public string? Category { get; init; }

        public string? ImageUrl { get; init; }
    }
}
