using ProjetPokeApi.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetPokeApi.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowPage : ContentPage
    {

        public ShowPage(MyPokemon param)
        {
            InitializeComponent();
            BindingContext = param;
        }
    }
}