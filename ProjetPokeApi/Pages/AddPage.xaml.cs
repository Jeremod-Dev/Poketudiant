
using ProjetPokeApi.Models;
using ProjetPokeApi.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetPokeApi.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        // Bouton validation du Pokemon
        public async void onClick(object sender, EventArgs args)
        {
            PokemonDataBase data = await PokemonDataBase.Instance;
            MyPokemon pokemon = new MyPokemon();
            pokemon.Id = 0;
            pokemon.Nom = nomInput.Text;
            pokemon.Poids = Int32.Parse(poidsInput.Text);
            pokemon.Type = typeInput.SelectedItem.ToString();

            Console.WriteLine(nomInput.Text + poidsInput.Text + typeInput.SelectedItem.ToString());

            ListViewModel.Instance.addPokemonToList(pokemon);
            await data.SaveItemAsync(pokemon);
        }
    }
}