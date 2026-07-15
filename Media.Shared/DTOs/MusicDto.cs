using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class MusicDto : MediaItemDto
    {
        public string Artist { get; set; }
        public string Writer { get; set;  }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public int RuntimeMinutes { get; set; } = 0;
        public int RuntimeSeconds { get; set; } = 0;
        public DateTime? FirstReleased { get; set; }
        public decimal Rating { get; set; }
        public string? CoverArtPath { get; set; }
        public string? MusicBrainzRecordingId { get; set; }

        public CreateMusicDto ToCreateMusic()
        {
            var newMusic = new CreateMusicDto()
            {
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath,
                Artist = Artist,
                Writer = Writer,
                Studio = Studio,
                Genre = Genre,
                RuntimeMinutes = RuntimeMinutes,
                RuntimeSeconds = RuntimeSeconds,
                FirstReleased = FirstReleased,
                Rating = Rating,
                CoverArtPath = CoverArtPath,
                MusicBrainzRecordingId = MusicBrainzRecordingId
            };
            return newMusic;
        }
    }

    public class CreateMusicDto : CreateMediaItemDto
    {
        public string Artist { get; set; }
        public string Writer { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public int RuntimeMinutes { get; set; } = 0;
        public int RuntimeSeconds { get; set; } = 0;
        public DateTime? FirstReleased { get; set; }
        public decimal Rating { get; set; }
        public string? CoverArtPath { get; set; }
        public string MusicBrainzRecordingId { get; set; }
    }
    public class UpdateMusicDto : UpdateMediaItemDto
    {
        public string Artist { get; set; }
        public string Writer { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public int RuntimeMinutes { get; set; } = 0;
        public int RuntimeSeconds { get; set; } = 0;
        public DateTime? FirstReleased { get; set; }
        public decimal Rating { get; set; }
        public string? CoverArtPath { get; set; }
        public string MusicBrainzRecordingId { get; set; }
        public CreateMusicDto ToCreateMusic()
        {
            var newMusic = new CreateMusicDto()
            {
                Title = Title,
                Description = Description,
                MediaType = MediaType,
                LibraryId = LibraryId,
                ThumbnailPath = ThumbnailPath,
                Artist = Artist,
                Writer = Writer,
                Studio = Studio,
                Genre = Genre,
                RuntimeMinutes = RuntimeMinutes,
                RuntimeSeconds = RuntimeSeconds,
                FirstReleased = FirstReleased,
                Rating = Rating,
                CoverArtPath = CoverArtPath,
                MusicBrainzRecordingId = MusicBrainzRecordingId
            };
            return newMusic;
        }
    }

    /*public class AlbumDto
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public List<MusicDto>? Tracks { get; set; }
    }*/
}
