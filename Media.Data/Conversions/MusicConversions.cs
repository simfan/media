using Medias.Data.Entities;
using Medias.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Conversions
{
    public static class MusicConversions
    {
        public static MusicDto MusicDetailToDto(MusicDetail music)
        {
            MusicDto musicDto = new MusicDto()
            {
                Artist = music.Artist,
                Writer = music.Writer,
                Genre = music.Genre,
                FirstReleased = music.FirstReleased,
                Rating = music.Rating,
                CoverArtPath = music.CoverArtPath,
                MusicBrainzRecordingId = music.MusicBrainzRecordingId
            };
            musicDto.RuntimeMinutes = TotalRuntimeToMiunutes(music.Runtime);
            musicDto.RuntimeSeconds = TotalRuntimeToRemainingSeconds(music.Runtime);

            return musicDto;
        }

        public static MusicDto ToMusicDto(MediaItem mediaItem)
        {
            MusicDto musicDto = new MusicDto();
            musicDto =(MusicDto) mediaItem.ToMediaItemDto();

            musicDto.Artist = mediaItem.MusicDetail.Artist;
            musicDto.Writer = mediaItem.MusicDetail.Writer;
            musicDto.Genre = mediaItem.MusicDetail.Genre;
            musicDto.FirstReleased = mediaItem.MusicDetail.FirstReleased;
            musicDto.Rating = mediaItem.MusicDetail.Rating;
            musicDto.CoverArtPath = mediaItem.MusicDetail.CoverArtPath;
            musicDto.MusicBrainzRecordingId = mediaItem.MusicDetail.MusicBrainzRecordingId;
            
            musicDto.RuntimeMinutes = TotalRuntimeToMiunutes(mediaItem.MusicDetail.Runtime);
            musicDto.RuntimeSeconds = TotalRuntimeToRemainingSeconds(mediaItem.MusicDetail.Runtime);

            return musicDto;
        }

        public static MusicDetail DtoToMusicDetail(MusicDto musicDto)
        {
            return new MusicDetail()
            {
                MediaItemId = musicDto.Id,
                Artist = musicDto.Artist,
                Writer = musicDto.Writer,
                Genre = musicDto.Genre,
                FirstReleased = musicDto.FirstReleased,
                Rating = musicDto.Rating,
                CoverArtPath = musicDto.CoverArtPath,
                MusicBrainzRecordingId = musicDto.MusicBrainzRecordingId,
                Runtime = ToTotalRuntime(musicDto.RuntimeMinutes, musicDto.RuntimeSeconds)
            };
        }

        public static MusicDetail CreateDtoToMusicDetail(this CreateMusicDto musicDto, int mediaItemId)
        {
            return new MusicDetail()
            {
                MediaItemId = mediaItemId,
                Artist = musicDto.Artist,
                Writer = musicDto.Writer,
                Studio = musicDto.Studio,
                Genre = musicDto.Genre,
                FirstReleased = musicDto.FirstReleased,
                Rating = musicDto.Rating,
                CoverArtPath = musicDto.CoverArtPath,
                MusicBrainzRecordingId = musicDto.MusicBrainzRecordingId,
                Runtime = ToTotalRuntime(musicDto.RuntimeMinutes, musicDto.RuntimeSeconds)
            };
        }

        public static MusicDetail UpdateDtoToMusicDetail(this UpdateMusicDto musicDto, MusicDetail existingEntity)
        {
            existingEntity.Artist = musicDto.Artist;
            existingEntity.Writer = musicDto.Writer;
            existingEntity.Studio = musicDto.Studio;
            existingEntity.Genre = musicDto.Genre;
            existingEntity.FirstReleased = musicDto.FirstReleased;
            existingEntity.Rating = musicDto.Rating;
            existingEntity.CoverArtPath = musicDto.CoverArtPath;
            existingEntity.MusicBrainzRecordingId = musicDto.MusicBrainzRecordingId;
            existingEntity.Runtime = ToTotalRuntime(musicDto.RuntimeMinutes, musicDto.RuntimeSeconds);
            return existingEntity;
        }

        public static int TotalRuntimeToMiunutes(int totalRuntime)
        {
            return totalRuntime/60;
        }
        public static int TotalRuntimeToRemainingSeconds(int totalRuntime)
        {
            return totalRuntime%60;
        }
        public static int ToTotalRuntime(int runtimeMinutes, int runtimeSeconds)
        {
            int runtimeMinutesInSeconds = runtimeMinutes * 60;
            return runtimeMinutesInSeconds + runtimeSeconds;
        }
    }
}
