using ProjetPokeApi.Models;
using ProjetPokeApi.ViewModel;
using System.Linq;
using Xamarin.Forms;

namespace ProjetPokeApi.Pages
{

    public partial class ListPage : ContentPage
    {

        public ListPage()
        {
            InitializeComponent();
            BindingContext = ListViewModel.Instance;
        }

        // Sender => Element sur lequel je clique || args => argument de l'object cliqué 
        void OnClickPokemonInList(object sender, SelectionChangedEventArgs args)
        {
            MyPokemon param = (args.CurrentSelection.FirstOrDefault() as MyPokemon);
            Navigation.PushModalAsync(new ShowPage(param));
        }

    } 

}