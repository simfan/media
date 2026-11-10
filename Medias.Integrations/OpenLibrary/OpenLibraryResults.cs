using System.Text.Json.Serialization;

namespace Medias.Integrations.OpenLibrary
{
    public class OpenLibraryResults
    {
        [JsonPropertyName("docs")]
        public List<OpenLibraryBookDTO> Books { get; set; } = [];
    }

    public class OpenLibraryBookDTO
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("author_name")]
        public string[] Authors { get; set; }
        [JsonPropertyName("publisher")]
        public string[] Publishers { get; set; }
        [JsonPropertyName("first_publish_year")]
        public int PublishDate { get; set; }
        [JsonPropertyName("key")]
        public string WorkKey { get; set; }
        [JsonPropertyName("cover_i")]
        public int? CoverId { get; set; }
        [JsonIgnore]
        public string CoverImageUrl => CoverId.HasValue ? $"https://covers.openlibrary.org/b/id/{CoverId}-M.jpg" : null;
    }
}
