using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RecipesSQLite.Persistance;
using SQLite;
using Xamarin.Forms;

namespace RecipesSQLite
{
	public class Recipe : INotifyPropertyChanged //interface for updating user interface
	{
        public event PropertyChangedEventHandler PropertyChanged;

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		private string _name;
		[MaxLength(255)]
		public string Name
        {
			get { return _name; }
            set
            {
				if (_name == value)
					return;

				_name = value;

				OnPropertyChanged();
            }
        }
		//method for property changed/updated event
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


	public partial class MainPage : ContentPage
	{
		private SQLiteAsyncConnection _connection;
		private ObservableCollection<Recipe> _recipes;

		public MainPage()
		{
			InitializeComponent();

			_connection = DependencyService.Get<ISQLiteDb>().GetConnection();
			
		}

        protected override async void OnAppearing()
        {
			await _connection.CreateTableAsync<Recipe>();

			var recipes = await _connection.Table<Recipe>().ToListAsync();
			_recipes = new ObservableCollection<Recipe>(recipes); 
			recipesListView.ItemsSource = _recipes;

			base.OnAppearing();
        }

       async void OnAdd(object sender, System.EventArgs e)
		{
			var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };
			await _connection.InsertAsync(recipe);
			_recipes.Add(recipe);
		}

		async void OnUpdate(object sender, System.EventArgs e)
		{
			var recipe = _recipes[0];
			recipe.Name += " Updated";
			await _connection.UpdateAsync(recipe);

		}

		async void OnDelete(object sender, System.EventArgs e)
		{
			var recipe = _recipes[0];
			await _connection.DeleteAsync(recipe);
			_recipes.Remove(recipe);
		}
	}
}