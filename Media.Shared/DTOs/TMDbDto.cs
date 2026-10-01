namespace Medias.Shared.DTOs
{
    public class TMDbDto
    {
    }
    public class TMDbMovieSearchResults
    {
        public List<TMDbMovieSearchRecord> Results { get; set; } = [];
    }

    public class TMDbMovieSearchRecord
    {
        public int ID { get; set;  }
        public string Title { get; set; } = string.Empty;
        public string? Overview { get; set;  }
        public string? Release_Date { get; set; }
        public string? Poster_Path { get; set; }
    }

    public class TMDbTVSearchResults
    {
        public List<TMDbTVSearchRecord> Results { get; set; } = [];
    }

    public class TMDbTVSearchRecord
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Overview { get; set; }
        public string First_Air_Date { get; set; }
        public string Last_Air_Date { get; set; }
        public string? Poster_Path { get; set; }
        public int Number_of_Seasons { get; set; }
        public int Number_of_Episodes { get; set; }

    }

    public class TMDbTVSeasonRecord
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Overview { get; set; }
        public string Air_Date { get; set; }
        public string? Poster_Path { get; set; }
        public int Season_Number { get; set; }
        public int Episode_Count { get; set; }
    }
}
