using System;
using System.Transactions;

namespace _02._Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int plyerRow = 0;
            int plyerCol = 0;
            bool isFinished = false;

            for (int row = 0; row < size; row++)
            {
                char[] matrixDetails = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixDetails[col];

                    if (matrixDetails[col] == 'f')
                    {
                        plyerRow = row;
                        plyerCol = col;
                    }
                }
            }

            for (int i = 0; i < count; i++)
            {
                string currentCommand = Console.ReadLine();

                MovePlyer(currentCommand ,matrix, size, ref plyerRow, ref plyerCol, ref isFinished);

                if (isFinished)
                {
                    break;
                }
            }

            if (isFinished)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            Print(matrix, size);
        }

        private static void MovePlyer(string currentCommand, char[,] matrix, int size, ref int plyerRow, ref int plyerCol, ref bool isFinished)
        {
            matrix[plyerRow, plyerCol] = '-';
            
            if (currentCommand == "up")
            {
                plyerRow --;

                if (plyerRow < 0)
                {
                    plyerRow = size - 1;
                }
                else if (matrix[plyerRow, plyerCol] == 'B')
                {
                    plyerRow--;

                    if (plyerRow < 0)
                    {
                        plyerRow = size - 1;
                    }
                }
                else if (matrix[plyerRow, plyerCol] == 'T')
                {
                    plyerRow++;
                }

                if (matrix[plyerRow, plyerCol] == 'F')
                {
                    matrix[plyerRow, plyerCol] = 'f';
                    isFinished = true;
                }
                else
                {
                    matrix[plyerRow, plyerCol] = 'f';
                }


            }
            else if (currentCommand == "down")
            {
                plyerRow ++;

                if (plyerRow > size - 1)
                {
                    plyerRow = 0;
                }
                else if (matrix[plyerRow, plyerCol] == 'B')
                {
                    plyerRow++;

                    if (plyerRow < 0)
                    {
                        plyerRow = 0;
                    }
                }
                else if (matrix[plyerRow, plyerCol] == 'T')
                {
                    plyerRow--;
                }

                if (matrix[plyerRow, plyerCol] == 'F')
                {
                    matrix[plyerRow, plyerCol] = 'f';
                    isFinished = true;
                }
                else
                {
                    matrix[plyerRow, plyerCol] = 'f';
                }
            }
            else if (currentCommand == "left")
            {
                plyerCol--;

                if (plyerCol < 0)
                {
                    plyerCol = size - 1;
                }
                else if (matrix[plyerRow, plyerCol] == 'B')
                {
                    plyerCol--;

                    if (plyerCol < 0)
                    {
                        plyerCol = size - 1;
                    }
                }
                else if (matrix[plyerRow, plyerCol] == 'T')
                {
                    plyerCol++;
                }

                if (matrix[plyerRow, plyerCol] == 'F')
                {
                    matrix[plyerRow, plyerCol] = 'f';
                    isFinished = true;
                }
                else
                {
                    matrix[plyerRow, plyerCol] = 'f';
                }

            }
            else if (currentCommand == "right")
            {
                plyerCol++;

                if (plyerCol > size - 1)
                {
                    plyerCol = 0;
                }
                else if (matrix[plyerRow, plyerCol] == 'B')
                {
                    plyerCol++;

                    if (plyerRow < 0)
                    {
                        plyerCol = 0;
                    }
                }
                else if (matrix[plyerRow, plyerCol] == 'T')
                {
                    plyerCol--;
                }

                if (matrix[plyerRow, plyerRow] == 'F')
                {
                    matrix[plyerRow, plyerCol] = 'f';
                    isFinished = true;
                }
                else
                {
                    matrix[plyerRow, plyerCol] = 'f';
                }
            }
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
