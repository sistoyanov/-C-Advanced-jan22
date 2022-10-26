using System;
using System.Linq;

namespace RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string number = Console.ReadLine();
            char[,] matrix = new char[size, size];

            int carRow = 0;
            int carCol = 0;
            int carKilometers = 0;

            int firstTunelRow = -1;
            int firstTunelCol = -1;
            int secondTunelRow = -1;
            int secondTunelCol = -1;
            int tunelCount = 0;

            for (int row = 0; row < size; row++)
            {
                char[] matrixDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixDetails[col];

                    if (matrixDetails[col] == 'T' && tunelCount == 0)
                    {
                        firstTunelRow = row;
                        firstTunelCol = col;
                        tunelCount++;
                    }
                    else if (matrixDetails[col] == 'T' && tunelCount > 0)
                    {
                        secondTunelRow = row;
                        secondTunelCol = col;
                    }
                }
            }

            bool isFinished = false;
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                matrix[carRow, carCol] = '.';

                if (input == "up")
                {
                    carRow--;

                    if (matrix[carRow, carCol] == '.')
                    {
                        carKilometers += 10;
                    }
                    else if (matrix[carRow, carCol] == 'T')
                    {
                        carKilometers += 30;

                        if (carRow == firstTunelRow && carCol == firstTunelCol)
                        {
                            carRow = secondTunelRow;
                            carCol = secondTunelCol;
                            matrix[firstTunelRow, firstTunelCol] = '.';
                        }
                        else if (carRow == secondTunelRow && carCol == secondTunelCol)
                        {
                            carRow = firstTunelRow;
                            carCol = firstTunelCol;
                            matrix[secondTunelRow, secondTunelCol] = '.';
                        }
                    }
                    else if (matrix[carRow, carCol] == 'F')
                    {
                        carKilometers += 10;
                        isFinished = true;
                        break;
                    }
                }
                else if (input == "down")
                {
                    carRow++;

                    if (matrix[carRow, carCol] == '.')
                    {
                        carKilometers += 10;
                    }
                    else if (matrix[carRow, carCol] == 'T')
                    {
                        carKilometers += 30;

                        if (carRow == firstTunelRow && carCol == firstTunelCol)
                        {
                            carRow = secondTunelRow;
                            carCol = secondTunelCol;
                            matrix[firstTunelRow, firstTunelCol] = '.';
                        }
                        else if (carRow == secondTunelRow && carCol == secondTunelCol)
                        {
                            carRow = firstTunelRow;
                            carCol = firstTunelCol;
                            matrix[secondTunelRow, secondTunelCol] = '.';
                        }
                    }
                    else if (matrix[carRow, carCol] == 'F')
                    {
                        carKilometers += 10;
                        isFinished = true;
                        break;
                    }
                }
                else if (input == "left")
                {
                    carCol--;

                    if (matrix[carRow, carCol] == '.')
                    {
                        carKilometers += 10;
                    }
                    else if (matrix[carRow, carCol] == 'T')
                    {
                        carKilometers += 30;

                        if (carRow == firstTunelRow && carCol == firstTunelCol)
                        {
                            carRow = secondTunelRow;
                            carCol = secondTunelCol;
                            matrix[firstTunelRow, firstTunelCol] = '.';
                        }
                        else if (carRow == secondTunelRow && carCol == secondTunelCol)
                        {
                            carRow = firstTunelRow;
                            carCol = firstTunelCol;
                            matrix[secondTunelRow, secondTunelCol] = '.';
                        }
                    }
                    else if (matrix[carRow, carCol] == 'F')
                    {
                        carKilometers += 10;
                        isFinished = true;
                        break;
                    }
                }
                else if (input == "right")
                {
                    carCol++;

                    if (matrix[carRow, carCol] == '.')
                    {
                        carKilometers += 10;
                    }
                    else if (matrix[carRow, carCol] == 'T')
                    {
                        carKilometers += 30;

                        if (carRow == firstTunelRow && carCol == firstTunelCol)
                        {
                            carRow = secondTunelRow;
                            carCol = secondTunelCol;
                            matrix[firstTunelRow, firstTunelCol] = '.';
                        }
                        else if (carRow == secondTunelRow && carCol == secondTunelCol)
                        {
                            carRow = firstTunelRow;
                            carCol = firstTunelCol;
                            matrix[secondTunelRow, secondTunelCol] = '.';
                        }
                    }
                    else if (matrix[carRow, carCol] == 'F')
                    {
                        carKilometers += 10;
                        isFinished = true;
                        break;
                    }
                }

                
            }

            matrix[carRow, carCol] = 'C';

            if (isFinished)
            {
                Console.WriteLine($"Racing car {number} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {number} DNF.");
            }

            Console.WriteLine($"Distance covered {carKilometers} km.");

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
