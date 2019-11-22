using ChuckNorrisJokesLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChuckNorrisJokeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public string[] Categories { get; set; }

        public CategoryPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var jokeGenerator = new JokeGenerator();
            Categories = await jokeGenerator.GetCatagories();
            BindingContext = this;      //current instance of the class
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            string Categories = (sender as Label).Text;
            HttpClient client = new HttpClient();
            string category = await client.GetStringAsync("https://api.chucknorris.io/jokes/random?category=" + Categories);
            var jokeFromCategory = JsonConvert.DeserializeObject<Joke>(category);
            var realJoke = jokeFromCategory.value;
            await DisplayAlert(Categories, realJoke, "ok");
        }
    }
}