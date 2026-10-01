using Medias.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Entities
{
    public class TelevisionSeason
    {
        public int SeasonId { get; set; }
        public int MediaItemId { get; set; }
        public int SeasonNumber { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int EpisodeCount { get; set; }
        public TelevisionShowDetail TelevisionShowDetail { get; set; }
        public List<TelevisionEpisode>? Episodes { get; set; }
       

    }
}
