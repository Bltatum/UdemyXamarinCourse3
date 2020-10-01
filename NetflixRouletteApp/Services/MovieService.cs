using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NetflixRouletteApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetflixRouletteApp.Services
{
    public class MovieService
    {
		public static readonly int MinSearchLength = 5;

		private const string Url = "https://www.omdbapi.com/?i=tt3896198&apikey=8e15c5b7&";
		private const string UrlTitle = "https://www.omdbapi.com/?apikey=8e15c5b7&";


		private HttpClient _client = new HttpClient();

		public async Task<IEnumerable<Movie>> FindMoviesByActor(string title)
		{
			if (title.Length < MinSearchLength)
				return Enumerable.Empty<Movie>();

			var response = await _client.GetAsync($"{Url}s={title}");

			if (response.StatusCode == HttpStatusCode.NotFound)
				return Enumerable.Empty<Movie>();

			var content = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<List<Movie>>(JObject.Parse(content)["Search"].ToString());
			
		}

		public async Task<Movie> GetMovie(string imdbId)
		{
			var response = await _client.GetAsync($"{UrlTitle}i={imdbId}");

			if (response.StatusCode == HttpStatusCode.NotFound)
				return null;

			var content = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<Movie>(content);
		}
	}
}



