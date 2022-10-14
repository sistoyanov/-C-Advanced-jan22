using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            Queue<string> commands = new Queue<string>(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries));

            int playerOneShips = 0;
            int playerTwoShips = 0;
            int shipsDestroyed = 0;

            for (int row = 0; row < size; row++)
            {
                char[] matrixDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixDetails[col];

                    if (matrix[row, col] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        playerTwoShips++;
                    }

                }
            }

            while (commands.Count > 0 && playerOneShips > 0 && playerTwoShips > 0)
            {
                string attackCordinates = commands.Dequeue();
                int[] attackRowAndCol = attackCordinates.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int attackRow = attackRowAndCol[0];
                int attackCol = attackRowAndCol[1];

                if (IsValid(attackRow, attackCol, size))
                {

                    if (matrix[attackRow, attackCol] == '#')
                    {
                        DetonateMine(size, attackRow, attackCol, matrix, ref playerOneShips, ref playerTwoShips, ref shipsDestroyed);
                    }
                    else if (matrix[attackRow, attackCol] == '<')
                    {
                        playerOneShips--;
                        shipsDestroyed++;
                        matrix[attackRow, attackCol] = 'X';
                    }
                    else if (matrix[attackRow, attackCol] == '>')
                    {
                        playerTwoShips--;
                        shipsDestroyed++;
                        matrix[attackRow, attackCol] = 'X';
                    }

                }

            }

            if (playerOneShips > 0 && playerTwoShips == 0)
            {
                Console.WriteLine($"Player One has won the game! {shipsDestroyed} ships have been sunk in the battle.");
            }
            else if (playerTwoShips > 0 && playerOneShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! {shipsDestroyed} ships have been sunk in the battle.");
            }
            else if (playerTwoShips > 0 && playerOneShips > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
        }

        private static void DetonateMine(int size,int mineRow, int mineCol, char[,] matrix, ref int playerOneShips, ref int playerTwoShips, ref int shipsDestroyed)
        {
            matrix[mineRow, mineCol] = 'X';
            
            if (IsValid(mineRow - 1, mineCol, size)) //Up
            {
                if (matrix[mineRow - 1, mineCol] == '<')
                {
                    playerOneShips--;
                    shipsDestroyed++;
                    matrix[mineRow - 1, mineCol] = 'X';
                }
                else if (matrix[mineRow - 1, mineCol] == '>')
                {
                    playerTwoShips--;
                    shipsDestroyed++;
                    matrix[mineRow - 1, mineCol] = 'X';
                }

            }

            if (IsValid(mineRow + 1, mineCol, size))// Down
            {
                if (matrix[mineRow + 1, mineCol] == '<')
                {
                    playerOneShips--;
                    shipsDestroyed++;
                    matrix[mineRow + 1, mineCol] = 'X';
                }
                else if (matrix[mineRow + 1, mineCol] == '>')
                {
                    playerTwoShips--;
                    shipsDestroyed++;
                    matrix[mineRow + 1, mineCol] = 'X';
                }

            }

            if (IsValid(mineRow, mineCol - 1, size)) //Left
            {
                if (matrix[mineRow, mineCol - 1] == '<')
                {
                    playerOneShips--;
                    shipsDestroyed++;
                    matrix[mineRow, mineCol - 1] = 'X';
                }
                else if (matrix[mineRow, mineCol -1] == '>')
                {
                    playerTwoShips--;
                    shipsDestroyed++;
                    matrix[mineRow, mineCol - 1] = 'X';
                }

            }

            if (IsValid(mineRow, mineCol + 1, size)) // Right
            {
                if (matrix[mineRow, mineCol + 1] == '<')
                {
                    playerOneShips--;
                    shipsDestroyed++;
                    matrix[mineRow, mineCol + 1] = 'X';
                }
                else if (matrix[mineRow, mineCol + 1] == '>')
                {
                    playerTwoShips--;
                    shipsDestroyed++;
                    matrix[mineRow, mineCol + 1] = 'X';
                }

            }

            if (IsValid(mineRow - 1, mineCol + 1, size)) // UpRight
            {
                if (matrix[mineRow - 1, mineCol + 1] == '<')
                {
                    playerOneShips--;
                    shipsDestroyed++;
                    matrix[mineRow - 1, mineCol + 1] = 'X';
                }
                else if (matrix[mineRow - 1, mineCol + 1] == '>')
                {
                    playerTwoShips--;
                    shipsDestroyed++;
                    matrix[mineRow - 1, mineCol + 1] = 'X';
                }

            }

            if (IsValid(mineRow + 1, mineCol + 1, size)) // DownRight
            {
                if (matrix[mineRow + 1, mineCol + 1] == '<')
                {
                    playerOneShips--;
                    shipsDestroyed++;
                    matrix[mineRow + 1, mineCol + 1] = 'X';
                }
                else if (matrix[mineRow + 1, mineCol + 1] == '>')
                {
                    playerTwoShips--;
                    shipsDestroyed++;
                    matrix[mineRow + 1, mineCol + 1] = 'X';
                }

            }

            if (IsValid(mineRow - 1, mineCol - 1, size)) // UpLeft
            {
                if (matrix[mineRow - 1, mineCol - 1] == '<')
                {
                    playerOneShips--;
                    shipsDestroyed++;
                    matrix[mineRow - 1, mineCol - 1] = 'X';
                }
                else if (matrix[mineRow - 1, mineCol - 1] == '>')
                {
                    playerTwoShips--;
                    shipsDestroyed++;
                    matrix[mineRow - 1, mineCol - 1] = 'X';
                }

            }

            if (IsValid(mineRow + 1, mineCol - 1, size)) // DownRight
            {
                if (matrix[mineRow + 1, mineCol - 1] == '<')
                {
                    playerOneShips--;
                    shipsDestroyed++;
                    matrix[mineRow + 1, mineCol - 1] = 'X';
                }
                else if (matrix[mineRow + 1, mineCol - 1] == '>')
                {
                    playerTwoShips--;
                    shipsDestroyed++;
                    matrix[mineRow + 1, mineCol - 1] = 'X';
                }

            }
        }

        private static bool IsValid (int row, int col, int size)
        {
            return (row >= 0 && row < size && col >= 0 && col < size);
        }
    }
}
