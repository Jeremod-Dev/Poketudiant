using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPokeApi.Models
{
    public class MyPokemon
    {
       
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Poids { get; set; }
        public string Type { get; set; }
    }
}
