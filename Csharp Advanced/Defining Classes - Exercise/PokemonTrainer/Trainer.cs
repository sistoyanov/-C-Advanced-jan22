using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.Bages = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int Bages { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

        public override string ToString()
        { 
            return $"{this.Name} {this.Bages} {this.Pokemons.Count}";
        }
    }
}
