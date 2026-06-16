using Medias.Data.Conversions;
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

    }
}
