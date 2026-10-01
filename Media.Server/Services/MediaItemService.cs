using Medias.Data.Conversions;
using Medias.Data.Entities;
using Medias.Server.Repositories;
using Medias.Shared.DTOs;

namespace Medias.Server.Services
{
    public class MediaItemService : IMediaItemService
    {
        private readonly IConfiguration _configuration;
        private readonly IMediaItemRepository _mediaItemRepository;
        public MediaItemService(IConfiguration configuration, IMediaItemRepository mediaItemRepository)
        {
            _configuration = configuration;
            _mediaItemRepository = mediaItemRepository;
        }

        public async Task<IEnumerable<MediaItemDtoFull>> GetMediaItemsAsync()
        {
            var mediaItems =  await _mediaItemRepository.GetMediaItems();
            List<MediaItemDtoFull> mediaItemFullDtos = new List<MediaItemDtoFull>();
            foreach (var mediaItem in mediaItems) {
               var mediaItemFullDto = mediaItem.ToMediaItemDtoFull();
                mediaItemFullDtos.Add(mediaItemFullDto);
            }
            return mediaItemFullDtos;
        }

        public async Task<MovieDto> GetMovieById(int id)
        {
            var movie = await _mediaItemRepository.GetMovieById(id);
            var movieDto = MovieConversions.ToMovieDto(movie);
            return movieDto;
        }


        public async Task<MovieDto> GetMovieByTmdbId(int id)
        {
            var movie = await _mediaItemRepository.GetMovieByTmdbId(id);
            var movieDto = MovieConversions.ToMovieDto(movie);
            return movieDto;
        }
        /*public  async Task<IEnumerable<MediaItemDtoFull>> GetMovies()
        {
            var movies = await _mediaItemRepository.GetMovies();
            List<MediaItemDtoFull> movieDtos = new List<MediaItemDtoFull>();
            foreach (var movie in movies)
            {
                var movieDto = movie.ToMediaItemDtoFull();
                movieDtos.Add(movieDto);
            }
            return movieDtos;
        }
        public async Task<TelevisionShowDto>GetTelevisionShowById(int id)
        {
            var tvShow = await _mediaItemRepository.GetTVShowById(id);
            var tvShowDto = TelevisionConversions.ToTelevisionShowDto(tvShow);
            return tvShowDto;
        }
        */

    }
}
