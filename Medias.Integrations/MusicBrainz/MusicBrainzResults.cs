using System.Text.Json.Serialization;

namespace Medias.Integrations.MusicBrainz
{

    public class MusicBrainzDTOs
    {
    }
    public class MusicBrainzReleaseGroupResults
    {
        [JsonPropertyName("release-groups")]
        public List<MusicBrainzReleaseGroupSearchResult>? ReleaseGroups { get; set; } = new List<MusicBrainzReleaseGroupSearchResult>();
    }
    public class MusicBrainzReleaseGroupSearchResult
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; } = "";
        [JsonPropertyName("primary-type")]


        public string? PrimaryType { get; set; }     // Album, EP, Single
        [JsonPropertyName("secondary-types")]
        public List<string> SecondaryTypes { get; set; } = [];


        [JsonPropertyName("first-release-date")]
        public string? FirstReleaseDate { get; set; }
        [JsonPropertyName("release-count")]
        public int? ReleaseCount { get; set; }
        [JsonPropertyName("score")]
        public int? Score { get; set; }

        [JsonPropertyName("artist-credit")]
        public List<MusicBrainzArtistCredit> ArtistCredits { get; set; } = [];
        [JsonPropertyName("releases")]
        public List<MusicBrainzReleaseSearchResult> Releases { get; set; } = [];
        [JsonIgnore]
        public string? Artist =>
        ArtistCredits.FirstOrDefault()?.Name;
        [JsonIgnore]
        public string? AlbumUrl => 
            $"https://coverartarchive.org/release/{Releases.FirstOrDefault()?.Id}/front";
    }

    public class MusicBrainzReleaseSearchResult
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        public Guid? ReleaseGroupId { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; } = "";
        [JsonPropertyName("artist-credit")]
        public List<MusicBrainzArtistCredit> Artist { get; set; }
        [JsonPropertyName("date")]
        public string? Date { get; set; }
        [JsonPropertyName("country")]
        public string? Country { get; set; }
        [JsonPropertyName("status")]
        public string? Status { get; set; }      // Official, Bootleg

        public string? Packaging { get; set; }

        public int? TrackCount { get; set; }
        [JsonPropertyName("barcode")]
        public string? Barcode { get; set; }

        public string? Format { get; set; }      // CD, Vinyl, Digital

        public int? Score { get; set; }
    }

    public class MusicBrainzRecordingSearchResult//MusicBrainzRecordingSearchResult
    {
        public List<MusicBrainzRecording>? Recordings { get; set; } = new List<MusicBrainzRecording>();
    }
    public class MusicBrainzRecording//MusicBrainzRecording
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("title")]

        public string Title { get; set; } = "";
        [JsonPropertyName("artist-credit")]
        public List<MusicBrainzArtistCredit> ArtistCredits { get; set; } = [];
        public Guid? ReleaseId { get; set; }
        [JsonPropertyName("length")]
        public int? LengthMilliseconds { get; set; }
        [JsonPropertyName("first-release-date")]
        public string? FirstReleaseDate { get; set; }
        [JsonPropertyName("video")]
        public bool? Video { get; set; }

        [JsonIgnore]
        public string? Artist =>
        ArtistCredits.FirstOrDefault()?.Name;
    }

    public class MusicBrainzArtistCredit
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("artist")]
        public MusicBrainzArtist? Artist { get; set; }
    }

    public class MusicBrainzArtist
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
    }

    /*public class MusicBrainzArtistDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string SortName { get; set; } = string.Empty;
        /*public string Disambiguation { get; set; } = string.Empty;
        public List<MusicBrainzReleaseGroupDTO> ReleaseGroups { get; set; } = new List<MusicBrainzReleaseGroupDTO>();*/
    /*}

    public class MusicBrainzReleaseGroupDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string PrimaryType { get; set; } = string.Empty;
        public string FirstReleaseDate { get; set; } = string.Empty;
    }

    public class MusicBrainzReleaseDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ReleaseDate { get; set; } = string.Empty;
        public List<MusicBrainzTrackDTO> Tracks { get; set; } = new List<MusicBrainzTrackDTO>();
    }

    public class MusicBrainzTrackDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Position { get; set; }
        public int Length { get; set; }
    }*/
}