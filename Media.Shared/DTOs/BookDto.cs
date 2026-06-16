using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class BookDto : MediaItemDto
    {
        public int Pages { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string BookFormat { get; set; }//HardCover, Paperback, Digital, Audio
        public int? TimeToRead { get; set; }
        public string? ISBN { get; set; }
        public string? OpenLibraryId { get; set; }

        /*public async string SearchByTitle(string title)
        {
            return await _httpClient.GetStringAsync(
            $"https://openlibrary.org/search.json?title={Uri.EscapeDataString(title)}");
        }*/
    }
}
