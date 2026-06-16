using Medias.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Data.Entities
{
    public class TelevisionShowDetail
    {
        public int MediaItemId { get; set; }
        public string CreatedBy { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public string? Status { get; set; }
        public int? TmdbTvId { get; set; }
        public string? ImdbId { get; set; }
        public int SeasonCount { get; set; }
        public List<TelevisionSeason>? Seasons { get; set; }
        public MediaItem MediaItem { get; set; }
    }
}
