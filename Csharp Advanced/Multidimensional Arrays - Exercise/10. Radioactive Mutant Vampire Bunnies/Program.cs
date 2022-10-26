using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            string[,] matrix = new string[rows, cols];

            int plyaerRow = 0;
            int plyaerCol = 0;
            
            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col].ToString();

                    if (matrix[row, col] == "P")
                    {
                        plyaerRow = row;
                        plyaerCol = col;
  
                    }
                }
            }

            string commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i].ToString();
                
                bool won = false;
                bool lost = false;

                int lastPositionRow = plyaerRow;
                int lastPositionCol = plyaerCol;

                if (currentCommand == "U") //Up
                {
                    matrix[plyaerRow, plyaerCol] = ".";
                    lastPositionRow--;
                    MovePlayer(matrix, lastPositionRow, plyaerCol, ref won, ref lost);
                }



                if (currentCommand == "D") //Down
                {
                    matrix[plyaerRow, plyaerCol] = ".";
                    lastPositionRow++;
                    MovePlayer(matrix, lastPositionRow, plyaerCol, ref won, ref lost);
                }

                if (currentCommand == "L") //Left
                {
                    matrix[plyaerRow, plyaerCol] = ".";
                    lastPositionCol--;
                    MovePlayer(matrix, plyaerRow, lastPositionCol, ref won, ref lost);
                }

                if (currentCommand == "R") //Right
                {
                    matrix[plyaerRow, plyaerCol] = ".";
                    lastPositionCol++;
                    MovePlayer(matrix, plyaerRow, lastPositionCol, ref won, ref lost);
                }

                matrix = SpeadBunnies(matrix, ref lost);

                if (won)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {plyaerRow} {plyaerCol}");
                    return;
                }

                plyaerRow = lastPositionRow;
                plyaerCol = lastPositionCol;

                if (lost)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {plyaerRow} {plyaerCol}");
                    return;
                }
            }

        }

        private static string[,] SpeadBunnies(string[,] matrix, ref bool lost)
        {
            string[,] newMatrix = CopyMatrix(matrix);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    
                    if (matrix[row, col] == "B")
                    {

                        if (IfExist(matrix, row - 1, col)) //Up
                        {
                            if (matrix[row - 1, col] == "P")
                            {
                                lost = true;
                            }
  
                            newMatrix[row - 1, col] = "B";
                        }

                        if (IfExist(matrix, row + 1, col)) //Down
                        {
                            if (matrix[row + 1, col] == "P")
                            {
                                lost = true;
                            }

                            newMatrix[row + 1, col] = "B";
                        }

                        if (IfExist(matrix, row, col - 1)) //Left
                        {
                            if (matrix[row, col - 1] == "P")
                            {
                                lost = true;
                            }

                            newMatrix[row, col - 1] = "B";
                        }

                        if (IfExist(matrix, row, col + 1)) //Right
                        {
                            if (matrix[row, col + 1] == "P")
                            {
                                lost = true;
                            }

                            newMatrix[row, col + 1] = "B";
                        }

                    }

                }
            }
     
            return newMatrix;
        }
        private static string[,] CopyMatrix(string[,] matrix)
        {
           string[,] copyMatrix = new string[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    copyMatrix[row, col] = matrix[row, col];
                }
            }

            return copyMatrix;
        }
        private static void MovePlayer(string[,] matrix, int playerRow, int playerCol, ref bool won, ref bool lost)
        {

            if (IfExist(matrix, playerRow, playerCol))
            {
                if (matrix[playerRow, playerCol] == "B")
                {
                    lost = true;
                }
                else
                {
                    matrix[playerRow, playerCol] = "P";
                }
            }
            else
            {
                won = true;
            }
        }
        private static bool IfExist(string[,] matrix, int currentRow, int currentCol)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            if (currentRow >= 0 && currentRow < rows && currentCol >= 0 && currentCol < cols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void PrintMatrix (string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
