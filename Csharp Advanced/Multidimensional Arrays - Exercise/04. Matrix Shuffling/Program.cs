using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                if (CheckComand(input, rows, cols))
                {
                    string[] commandArg = input.Split();
                    string command = commandArg[0];
                    int RowToSwap = int.Parse(commandArg[1]);
                    int ColToSwapOne = int.Parse(commandArg[2]);
                    int RowToSwapWith = int.Parse(commandArg[3]);
                    int ColToSwapWith = int.Parse(commandArg[4]);

                    string tempValue = matrix[RowToSwap, ColToSwapOne];
                    matrix[RowToSwap, ColToSwapOne] = matrix[RowToSwapWith, ColToSwapWith];
                    matrix[RowToSwapWith, ColToSwapWith] = tempValue;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }

                Console.WriteLine();
            }

            return;
        }

        static bool CheckComand(string input, int rows, int cols)
        {
            string[] commandDetails = input.Split();
            string command = commandDetails[0];

            if (commandDetails.Length == 5 && command == "swap")
            {
                int firstRowToSwap = int.Parse(commandDetails[1]);
                int firstColToSwap = int.Parse(commandDetails[2]);
                int secondRowToSwap = int.Parse(commandDetails[3]);
                int secondColToSwap = int.Parse(commandDetails[4]);

                if ( 
                    firstRowToSwap >= 0 && firstRowToSwap < rows &&
                    firstColToSwap >= 0 && firstColToSwap < cols &&
                    secondRowToSwap >= 0 && secondRowToSwap < rows &&
                    secondColToSwap >= 0 && secondColToSwap < cols
                    )
                {
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }
            
        }
    }
}
