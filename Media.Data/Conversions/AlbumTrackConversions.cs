using Medias.Data.Entities;
using Medias.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Conversions
{
    public static class AlbumTrackConversions
    {
        public static TrackDto ToTrackDto(this AlbumTrack entity)
        {
            var trackDto = new TrackDto()
            {
                TrackId = entity.TrackId,
                TrackNumber = entity.TrackNumber,
                DiscNumber = entity.TrackNumber,
                AlbumId = entity.CollectionId,
                MusicId = entity.MediaItemId
            };
            var music = entity.MusicDetail;
            MusicDto musicDto = MusicConversions.MusicDetailToDto(music);
            trackDto.Music = musicDto;
            return trackDto;

        }
    }
}
