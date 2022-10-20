using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaveratWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int beaverRow = 0;
            int beaverCol = 0;
            List<char> woodBranches = new List<char>();

            for (int row = 0; row < size; row++)
            {
                char[] matrixDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixDetails[col];

                    if (matrixDetails[col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                }
            }

            //Console.WriteLine();
            //Print(matrix, size);

            string input = string.Empty;
            int branchCount = BranchCount(matrix, size);
            while ((input = Console.ReadLine()) != "end" && branchCount > 0)
            {

                if (input == "up" && IsValid(beaverRow - 1, beaverCol, size))
                {
                    matrix[beaverRow, beaverCol] = '-';
                    beaverRow--;

                    if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';

                        if (beaverRow == 0)
                        {
                            beaverRow = size - 1;
                        }
                        else
                        {
                            beaverRow = 0;
                        }
                    }

                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        woodBranches.Add(matrix[beaverRow, beaverCol]);
                        branchCount--;
                    }

                    matrix[beaverRow, beaverCol] = 'B';
                }
                else if (input == "down" && IsValid(beaverRow + 1, beaverCol, size))
                {
                    matrix[beaverRow, beaverCol] = '-';
                    beaverRow++;

                    if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';

                        if (beaverRow == size - 1)
                        {
                            beaverRow = 0;
                        }
                        else
                        {
                            beaverRow = size - 1;
                        }
                    }

                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        woodBranches.Add(matrix[beaverRow, beaverCol]);
                        branchCount--;
                    }

                    matrix[beaverRow, beaverCol] = 'B';
                }
                else if (input == "left" && IsValid(beaverRow, beaverCol - 1, size))
                {
                    matrix[beaverRow, beaverCol] = '-';
                    beaverCol--;

                    if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';

                        if (beaverCol == 0)
                        {
                            beaverCol = size - 1;
                        }
                        else
                        {
                            beaverCol = 0;
                        }
                    }

                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        woodBranches.Add(matrix[beaverRow, beaverCol]);
                        branchCount--;
                    }

                    matrix[beaverRow, beaverCol] = 'B';
                }
                else if (input == "right" && IsValid(beaverRow, beaverCol + 1, size))
                {
                    matrix[beaverRow, beaverCol] = '-';
                    beaverCol++;

                    if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';

                        if (beaverCol == size - 1)
                        {
                            beaverCol = 0;
                        }
                        else
                        {
                            beaverCol = size - 1;
                        }
                    }

                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        woodBranches.Add(matrix[beaverRow, beaverCol]);
                        branchCount--;
                    }

                    matrix[beaverRow, beaverCol] = 'B';
                }
                else
                {
                    if (woodBranches.Count > 0)
                    {
                        woodBranches.RemoveAt(woodBranches.Count - 1);
                    }
                }

                //Console.WriteLine();
                //Print(matrix, size);
            }

            if (branchCount <= 0)
            {
                Console.WriteLine($"The Beaver successfully collect {woodBranches.Count} wood branches: {string.Join(", ", woodBranches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchCount} branches left.");
            }

            Print(matrix, size);

            static void Print(char[,] matrix, int size)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }

                    Console.WriteLine();
                }
            }

            static bool IsValid(int row, int col, int size) => (row >= 0 && row < size && col >= 0 && col < size);

            static int BranchCount(char[,] matrix, int size)
            {
                int count = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (char.IsLower(matrix[row, col]))
                        {
                            count++;
                        }
                    }

                }

                return count;
            }
        }
    }
}
