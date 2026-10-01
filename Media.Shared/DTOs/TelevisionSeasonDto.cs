using System;
using System.Collections.Generic;
using System.Text;

namespace Medias.Shared.DTOs
{
    public class TelevisionSeasonDto
    {
        public int SeasonId { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonNumber { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int EpisodeCount { get; set; }
        public List<TelevisionEpisodeDto>? Episodes { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateTelevisionSeasonDto
    {
        public int TelevisionShowId { get; set; }
        public int SeasonNumber { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int EpisodeCount { get; set; }
    }

    public class UpdateTelevisionSeasonDto
    {
        public int SeasonId { get; set; }
        public int TelevisionShowId { get; set; }
        public int SeasonNumber { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int EpisodeCount { get; set; }
    }
}
