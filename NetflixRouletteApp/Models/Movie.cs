using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NetflixRouletteApp.Models
{

    public class Movie
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbID { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Poster")]
        public Uri Poster { get; set; }

        [JsonProperty("Plot")]
        public string Plot { get; set; }
    }

  

}
