using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipesSQLite
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RESTFulAPI();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
