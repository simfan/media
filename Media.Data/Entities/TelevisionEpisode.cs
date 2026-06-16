using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Entities
{
    public class TelevisionEpisode
    {
        public int EpisodeId { get; set; }
        public int EpisodeNumber { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonId { get; set; }
        public int SeasonNumber { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Director { get; set; }
        public int Runtime { get; set; }
        public decimal? Rating { get; set; }
        public DateTime? AirDate { get; set; }
        public TelevisionSeason TelevisionSeason { get; set; }
    }
}
