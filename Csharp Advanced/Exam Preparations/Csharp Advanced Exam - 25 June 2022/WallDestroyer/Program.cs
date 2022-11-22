using System;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int vankoRow = 0;
            int vankoCol = 0;
            int holesCount = 1;
            int rodsCount = 0;

            for (int row = 0; row < size; row++)
            {
                char[] matrixDetails = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixDetails[col];

                    if (matrixDetails[col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }

            string input = string.Empty;
            bool isElectrocuted = false;

            while ((input = Console.ReadLine()) != "End")
            {
                string command = input;

                if (command == "up" && vankoRow - 1 >= 0)
                {
                    vankoRow--;

                    if (matrix[vankoRow, vankoCol] == '*')
                    {
                        matrix[vankoRow + 1, vankoCol] = '*';
                        matrix[vankoRow, vankoCol] = 'V';
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                    else if (matrix[vankoRow, vankoCol] == 'R')
                    {
                        vankoRow++;
                        rodsCount++;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (matrix[vankoRow, vankoCol] == 'C')
                    {
                        holesCount++;
                        matrix[vankoRow + 1, vankoCol] = '*';
                        matrix[vankoRow, vankoCol] = 'E';
                        isElectrocuted = true;
                        break;
                    }
                    else
                    {

                        holesCount++;
                        matrix[vankoRow + 1, vankoCol] = '*';
                        matrix[vankoRow, vankoCol] = 'V';
                    }
                }
                else if (command == "down" && vankoRow + 1 < size)
                {
                    vankoRow++;

                    if (matrix[vankoRow, vankoCol] == '*')
                    {
                        matrix[vankoRow - 1, vankoCol] = '*';
                        matrix[vankoRow, vankoCol] = 'V';
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                    else if (matrix[vankoRow, vankoCol] == 'R')
                    {
                        vankoRow--;
                        rodsCount++;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (matrix[vankoRow, vankoCol] == 'C')
                    {
                        holesCount++;
                        matrix[vankoRow - 1, vankoCol] = '*';
                        matrix[vankoRow, vankoCol] = 'E';
                        isElectrocuted = true;
                        break;
                    }
                    else
                    {

                        holesCount++;
                        matrix[vankoRow - 1, vankoCol] = '*';
                        matrix[vankoRow, vankoCol] = 'V';
                    }
                }
                else if (command == "left" && vankoCol - 1 >= 0)
                {
                    vankoCol--;

                    if (matrix[vankoRow, vankoCol] == '*')
                    {
                        matrix[vankoRow, vankoCol] = 'V';
                        matrix[vankoRow, vankoCol + 1] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                    else if (matrix[vankoRow, vankoCol] == 'R')
                    {
                        vankoCol++;
                        rodsCount++;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (matrix[vankoRow, vankoCol] == 'C')
                    {
                        holesCount++;
                        matrix[vankoRow, vankoCol + 1] = '*';
                        matrix[vankoRow, vankoCol] = 'E';
                        isElectrocuted = true;
                        break;
                    }
                    else
                    {

                        holesCount++;
                        matrix[vankoRow, vankoCol + 1] = '*';
                        matrix[vankoRow, vankoCol] = 'V';
                    }
                }
                else if (command == "right" && vankoCol + 1 < size)
                {
                    vankoCol++;

                    if (matrix[vankoRow, vankoCol] == '*')
                    {
                        matrix[vankoRow, vankoCol] = 'V';
                        matrix[vankoRow, vankoCol - 1] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                    else if (matrix[vankoRow, vankoCol] == 'R')
                    {
                        vankoCol--;
                        rodsCount++;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (matrix[vankoRow, vankoCol] == 'C')
                    {
                        holesCount++;
                        matrix[vankoRow, vankoCol - 1] = '*';
                        matrix[vankoRow, vankoCol] = 'E';
                        isElectrocuted = true;
                        break;
                    }
                    else
                    { 
                        holesCount++;
                        matrix[vankoRow, vankoCol - 1] = '*';
                        matrix[vankoRow, vankoCol] = 'V';
                    }
                }
            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodsCount} rod(s).");
            }

            Print(matrix, size);
        }

        private static void Print(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
