using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Trainer> trainers = new List<Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = inputDetails[0];
                string pokemonName = inputDetails[1];
                string pokemonElement = inputDetails[2];
                int pokemonHealth = int.Parse(inputDetails[3]);

                Pokemon pokemonToAdd = new Pokemon(pokemonName,pokemonElement,pokemonHealth);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    trainers.Add(newTrainer);
                    newTrainer.AddPokemon(pokemonToAdd);
                }
                else
                {
                    Trainer currentTrainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                    currentTrainer.AddPokemon(pokemonToAdd);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string currentCommand = input;
                CheckPokemons(currentCommand, trainers);
            }

            trainers = trainers.OrderByDescending(t => t.Bages).ToList();

            foreach (var trainer in trainers)
            {
                Console.WriteLine(trainer);
            }
        }

        private static void CheckPokemons(string currentComand, List<Trainer> trainers)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == currentComand))
                {
                    trainer.Bages++;
                }
                else
                {
                    trainer.Pokemons.ForEach(p => p.Health -= 10);
                    trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                }

            }
        }
    }
}
