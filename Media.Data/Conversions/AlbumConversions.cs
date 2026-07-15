using Medias.Data.Entities;
using Medias.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Conversions
{
    public static class AlbumConversions
    {
        public static Album ToAlbum(this AlbumDto dto)
        {
            return new Album
            {
                CollectionId = dto.CollectionId,
                Artist = dto.Artist,
                Studio = dto.Studio,
                ReleaseDate = dto.ReleaseDate,
                Genre = dto.Genre,
                CoverArtPath = dto.CoverArtPath,
                MusicBrainzReleaseId = dto.MusicBrainzReleaseId,
                MusicBrainzReleaseGroupId = dto.MusicBrainzReleaseGroupId,
            };
        }

        public static Album CreateDtoToAlbum(this CreateAlbumDto dto, int collectionId)
        {
            return new Album
            {
                CollectionId = collectionId,
                Artist = dto.Artist,
                Studio = dto.Studio,
                ReleaseDate = dto.ReleaseDate,
                Genre = dto.Genre,
                CoverArtPath = dto.CoverArtPath,
                MusicBrainzReleaseId = dto.MusicBrainzReleaseId,
                MusicBrainzReleaseGroupId = dto.MusicBrainzReleaseGroupId
            };
        }
        public static AlbumDto ToAlbumDto(this Collection entity)
        {
            var albumDto =  new AlbumDto()
            {
                CollectionId = entity.CollectionId,
                Name = entity.Name,
                Description = entity.Description,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate,
                Artist = entity.Album.Artist,
                Studio = entity.Album.Studio,
                ReleaseDate = entity.Album.ReleaseDate,
                Genre = entity.Album.Genre,
                CoverArtPath = entity.Album.CoverArtPath,
                MusicBrainzReleaseId = entity.Album.MusicBrainzReleaseId,
                MusicBrainzReleaseGroupId = entity.Album.MusicBrainzReleaseGroupId,
                TrackCount = entity.Album.Tracks.Count(),

            };

            foreach(var track in entity.Album.Tracks)
            {
                //var trackDto = new TrackDto();
                var trackDto = track.ToTrackDto();
                albumDto.Tracks.Add(trackDto);
            }

            return albumDto;
        }
    }
}
