using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Medias.Shared.DTOs
{
    public class BarcodeProductDTO
    {
        /// <summary>
        /// Gets the status of the barcode lookup.
        /// </summary>
        /*public BarcodeLookupStatus Status { get; init; }*/
        public int Id { get; set; }
        public string Barcode { get; set; } = string.Empty;

        public string? Title { get; set; }
        public string? NormalizedTitle { get; set; }

        public string? Description { get; set; }

        public string? Brand { get; set; }

        public string? Category { get; set; }

        public string? ImageUrl { get; set; }

        public void TitleNormalization(string? title)
        {
            /*if(string.IsNullOrEmpty(title))
            {
                NormalizedTitle = title;
                return;
            }*/
            var normalized = title?.Trim();
            // Remove physical media formats and any trailing
            // distributor/category information after them.
            normalized = Regex.Replace(normalized, @"\s*\((?:4K\s*Ultra\s*HD|Blu-ray|DVD)(?:\s*\+\s*(?:Blu-ray|DVD))?\)\s*.*$",
        "", RegexOptions.IgnoreCase);
            // Remove known catalog classifications and format suffixes.
            normalized = Regex.Replace(normalized, @"\s+-\s+Music\s*&\s*Performance\s+-\s*CD\s*$",
        "",
        RegexOptions.IgnoreCase);
            normalized = Regex.Replace(normalized, @"\s*(\[|\()(?:SteelBook|Digital\s*Copy)(\)|\])", "", RegexOptions.IgnoreCase);
            NormalizedTitle = normalized.Trim();
            //string[] tempTitle = title.Split("(");
        }

        public void CategoryNormalization(string category)
        {
            if(category.Contains("Television"))
                Category = "Video";
            else if(category.Contains("CD"))
                Category = "Audio";
            else if (category.Contains("Books"))
                Category = "Print";
            else 
                Category = "Unknown";
        }
    }
}
