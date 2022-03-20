using ProjetPokeApi.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ProjetPokeApi
{
    // Initialisation de l'instance
    public class AsyncLazy<T>
    {
        readonly Lazy<Task<T>> instance;

        public AsyncLazy(Func<T> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }

        public AsyncLazy(Func<Task<T>> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }

        public TaskAwaiter<T> GetAwaiter()
        {
            return instance.Value.GetAwaiter();
        }
    }
    //Interface entre l'application dorsale et la BDD
    public class PokemonDataBase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<PokemonDataBase> Instance = new AsyncLazy<PokemonDataBase>(async () =>
        {
            var instance = new PokemonDataBase();
            CreateTableResult result = await Database.CreateTableAsync<MyPokemon>();
            return instance;
        });

        //Constuctor de la BDD
        public PokemonDataBase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        //Recuperation de l'ensemble des pokemons dans la BDD
        public Task<List<MyPokemon>> GetItemsAsync()
        {
            return Database.Table<MyPokemon>().ToListAsync();
        }

        // Recuperation d'un pokemon dans la BDD en fonction de son id
        public Task<MyPokemon> GetItemAsync(int id)
        {
            return Database.Table<MyPokemon>().Where(pokemon => pokemon.Id == id).FirstOrDefaultAsync();
        }

        //Sauver un pokemon en BDD
        public Task<int> SaveItemAsync(MyPokemon pokemon)
        {
            return Database.InsertAsync(pokemon);
        }

        // Suppression d'un pekomon en BDD
        public Task<int> DeleteItemAsync(MyPokemon pokemon)
        {
            return Database.DeleteAsync(pokemon);
        }

        // Retourne vrai si la BDD est vide
        public Task<bool> isPokemonDatabaseEmptyAsync() {
            return Task.Run(() => 0 == Database.Table<MyPokemon>().ToListAsync().Result.Count); 
        }
    }
}
