using System;
using System.Collections.Generic;
using NetflixRouletteApp.Models;
using NetflixRouletteApp.Services;
using Xamarin.Forms;

namespace NetflixRouletteApp
{ 
		public partial class MovieDetailPage : ContentPage
		{
			private MovieService _movieService = new MovieService();
			private Movie _movie;

			public MovieDetailPage(Movie movie)
			{
				if (movie == null)
					throw new ArgumentNullException(nameof(movie));

				_movie = movie;

				InitializeComponent();
			}

			protected override async void OnAppearing()
			{
				BindingContext = await _movieService.GetMovie(_movie.ImdbID);

				base.OnAppearing();
			}
		}
	
}
