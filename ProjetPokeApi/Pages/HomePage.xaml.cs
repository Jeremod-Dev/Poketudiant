
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetPokeApi.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Hello World!");
            label.Text = "Installation de linux sur l'appareil en cours...";

        }
    }
}