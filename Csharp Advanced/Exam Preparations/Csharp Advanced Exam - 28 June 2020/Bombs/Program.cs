using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>();
            Stack<int> bombCasings = new Stack<int>();

            int daturaBombsCount = 0; // 40
            int cherryBombsCount = 0; // 60
            int smokeDecoyBombsCount = 0; // 120
            bool isSuccessfull = false;
           

            int[] bombEffectElements = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] bombCasingtElements = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            foreach (var bombEffect in bombEffectElements)
            {
                bombEffects.Enqueue(bombEffect);
            }

            foreach (var bombCasing in bombCasingtElements)
            {
                bombCasings.Push(bombCasing);
            }

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                int currentBombEffect = bombEffects.Peek();
                int currentBombCasing = bombCasings.Pop();

                if (currentBombEffect + currentBombCasing == 40) //Datura
                {
                    daturaBombsCount++;
                    bombEffects.Dequeue();
                }
                else if (currentBombEffect + currentBombCasing == 60) //Cherry
                {
                    cherryBombsCount++;
                    bombEffects.Dequeue();
                }
                else if (currentBombEffect + currentBombCasing == 120) //Smoke Decoy 
                {
                    smokeDecoyBombsCount++;
                    bombEffects.Dequeue();
                }
                else
                {
                    currentBombCasing -= 5;
                    bombCasings.Push(currentBombCasing);
                }

                if (daturaBombsCount >= 3 && cherryBombsCount >= 3 && smokeDecoyBombsCount >= 3)
                {
                   isSuccessfull = true;
                   break;
                }
            }

            if (isSuccessfull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombsCount}");
            Console.WriteLine($"Datura Bombs: {daturaBombsCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombsCount}");
        }
    }
}
