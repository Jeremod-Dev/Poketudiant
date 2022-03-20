using PokeApiNet;
using ProjetPokeApi.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProjetPokeApi.ViewModel
{

    internal class ListViewModel : BaseViewModel
    {
        static int NB_POKEMON = 50; // Nombre de pokemon affiché dans la liste
        public static ListViewModel _instance = new ListViewModel();
        public static ListViewModel Instance => _instance;

        internal object ShowPoke(Pokemon param)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<MyPokemon> ListofPokemon
        {
            get => GetValue<ObservableCollection<MyPokemon>>();
            set
            {
                SetValue(value);
            }
        }

        public ListViewModel()
        {
            ListofPokemon = new ObservableCollection<MyPokemon>();
            InitList();
        }

        // Ajout d'un pokemon dans la liste de pokemon
        public void addPokemonToList(MyPokemon pokemon)
        {
            ListofPokemon.Add(pokemon);
        }

        private async void InitList()
        {
            PokemonDataBase data = await PokemonDataBase.Instance;
            PokeApiClient pokeClient = new PokeApiClient();

            if (data.isPokemonDatabaseEmptyAsync().Result) { // Si la BDD est vide
                for (int i = 1; i < NB_POKEMON; i++)
                {
                    Pokemon poke = await Task.Run(async () => await pokeClient.GetResourceAsync<Pokemon>(i));

                    MyPokemon mypokemon;

                    if (poke.Types.Count > 1)
                    {
                        mypokemon = new MyPokemon
                        {
                            Id = poke.Id,
                            Nom = poke.Name,
                            Poids = poke.Weight,
                            Type = poke.Types[0].Type.Name + " " + poke.Types[1].Type.Name
                        };
                    }
                    else
                    {
                        mypokemon = new MyPokemon
                        {
                            Id = poke.Id,
                            Nom = poke.Name,
                            Poids = poke.Weight,
                            Type = poke.Types[0].Type.Name

                        };
                    }
                    ListofPokemon.Add(mypokemon);
                    await data.SaveItemAsync(mypokemon);
                }
            }
            else // Si la BDD est plein
            {
                foreach (MyPokemon pokemon in await data.GetItemsAsync())
                {
                    ListofPokemon.Add(pokemon);
                }
            }

        }

    }
}
