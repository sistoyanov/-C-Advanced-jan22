using System;
using System.ComponentModel;

namespace PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 8;
            char[,] matrix = new char[size, size];
            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;

            for (int row = 0; row < size; row++)
            {
                char[] rowDetails = Console.ReadLine().ToCharArray();
                
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowDetails[col];

                    if (rowDetails[col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    else if (rowDetails[col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            bool isWhiteTurn = true;

            while (true)
            {
                if (isWhiteTurn)
                {

                    if (whiteRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(97 + whiteCol)}8.");
                        break;
                    }

                    if (IsValid(whiteRow - 1, whiteCol - 1, size) && matrix[whiteRow - 1, whiteCol - 1] == 'b') // Up & Left
                    {
                        whiteRow--;
                        whiteCol--;
                        Console.WriteLine($"Game over! White capture on {(char)(97 + whiteCol)}{size - whiteRow}.");
                        break;
                    }
                    else if (IsValid(whiteRow - 1, whiteCol + 1, size) && matrix[whiteRow - 1, whiteCol + 1] == 'b') // Up & Right
                    {
                        whiteRow--;
                        whiteCol++;
                        Console.WriteLine($"Game over! White capture on {(char)(97 + whiteCol)}{size - whiteRow}.");
                        break;
                    }

                    whiteRow--;
                    matrix[whiteRow, whiteCol] = 'w';

                }
                else
                {

                    if (blackRow == size - 1)
                    { 
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(97 + blackCol)}1.");
                        break;
                    }

                    if (IsValid(blackRow + 1, blackCol - 1, size) && matrix[blackRow + 1, blackCol - 1] == 'w') //Down & Left
                    {
                        blackRow++;
                        blackCol--;
                        Console.WriteLine($"Game over! Black capture on {(char)(97 + blackCol)}{size - blackRow}.");
                        break;
                    }
                    else if (IsValid(blackRow + 1, blackCol + 1, size) && matrix[blackRow + 1, blackCol + 1] == 'w') //Down & Right
                    {
                        blackRow++;
                        blackCol++;
                        Console.WriteLine($"Game over! Black capture on {(char)(97 + blackCol)}{size - blackRow}.");
                        break;
                    }

                    blackRow++;
                    matrix[blackRow, blackCol] = 'b';
                }

                isWhiteTurn = !isWhiteTurn;
            }
        }

        private static bool IsValid(int row, int col, int size)
        {
            return (row >= 0 && row < size && col >= 0 && col < size);
        }
    }
}
