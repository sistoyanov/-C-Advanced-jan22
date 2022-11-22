using System;
using System.Linq;

namespace TheBattleofTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armyArrmor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] map = new char[rows][];
            int armyRow = 0;
            int armyCol = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] rowDetails = Console.ReadLine().ToCharArray();
                map[row] = rowDetails;

                if (rowDetails.Contains('A'))
                {
                    armyRow = row;
                    armyCol = rowDetails.ToList().IndexOf('A');
                }
            }


            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                int orcRow = int.Parse(input[1]);
                int orcCol = int.Parse(input[2]);

                map[orcRow][orcCol] = 'O';
                map[armyRow][armyCol] = '-';
                armyArrmor--;

                if (command == "up" && armyRow - 1 >=0)
                {
                    armyRow--;
                }
                else if (command == "down" && armyRow + 1 < rows)
                {
                    armyRow++;
                }
                else if (command == "left" && armyCol - 1 >= 0)
                {
                    armyCol--;
                }
                else if (command == "right" && armyCol + 1 < map[0].Length)
                {
                    armyCol++;
                }


                if (map[armyRow][armyCol] == 'O')
                {
                    armyArrmor -= 2;
                }
                else if (map[armyRow][armyCol] == 'M')
                {
                    map[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArrmor}");
                    break;
                }

                if (armyArrmor <= 0)
                {
                    map[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }

                map[armyRow][armyCol] = 'A';

            }

            Print(rows, map);
        }

        static void Print(int rows, char[][] map)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(String.Join("", map[row]));
            }
        }
    }
}
