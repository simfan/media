using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Medias.Integrations.OpenLibrary
{
    public class OpenLibraryEdition
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("number_of_pages")]
        public int? Pages { get; set; }

        [JsonPropertyName("isbn_10")]
        public string[] Isbn10 { get; set; }

        [JsonPropertyName("isbn_13")]
        public string[] Isbn13 { get; set; }

        [JsonPropertyName("publish_date")]
        public string PublishDate { get; set; }

        [JsonPropertyName("publishers")]
        public string[] Publishers { get; set; }

        [JsonPropertyName("covers")]
        public List<int> Covers { get; set; }

        [JsonPropertyName("key")]
        public string EditionKey { get; set; }

        [JsonIgnore]
        public string CoverImageUrl => (Covers != null && Covers.Count > 0)
            ? $"https://covers.openlibrary.org/b/id/{Covers[0]}-M.jpg"
            : null;

        [JsonIgnore]
        public string PrimaryIsbn => Isbn13?.FirstOrDefault() ?? Isbn10?.FirstOrDefault();
    }
}
