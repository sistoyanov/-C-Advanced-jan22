using System;
using System.Runtime.CompilerServices;

namespace _02._Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int beeRow = 0;
            int beeCol = 0;
            int flowersFound = 0;
            bool isOut = false;

            for (int row = 0; row < size; row++)
            {
                char[] matrixDetails = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixDetails[col];

                    if (matrixDetails[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "up")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow--;

                    if (IsValid(size, beeRow, beeCol))
                    {
                        if (matrix[beeRow, beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeRow--;
                        }

                        MoveBee(ref flowersFound, beeRow, beeCol, matrix);
                    }
                    else
                    {
                        isOut = true;
                    }
                }
                else if (input == "down")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow++;

                    if (IsValid(size, beeRow, beeCol))
                    {
                        if (matrix[beeRow, beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeRow++;
                        }

                        MoveBee(ref flowersFound, beeRow, beeCol, matrix);
                    }
                    else
                    {
                        isOut = true;
                    }
                }
                else if (input == "left")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeCol--;

                    if (IsValid(size, beeRow, beeCol))
                    {
                        if (matrix[beeRow, beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeCol--;
                        }

                        MoveBee(ref flowersFound, beeRow, beeCol, matrix);
                    }
                    else
                    {
                        isOut = true;
                    }
                }
                else if (input == "right")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeCol++;

                    if (IsValid(size, beeRow, beeCol))
                    {
                        if (matrix[beeRow, beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeCol++;
                        }

                        MoveBee(ref flowersFound, beeRow, beeCol, matrix);
                    }
                    else
                    {
                        isOut = true;
                    }
                }

                if (isOut)
                {
                    break;
                }
            }

            if (isOut)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (flowersFound >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowersFound} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowersFound} flowers more");
            }

            Print(matrix, size);
        }

        public static void MoveBee(ref int folowesFound, int beeRow, int beeCol, char[,] matrix)
        {
            if (matrix[beeRow, beeCol] == 'f')
            {
                folowesFound++;
            }
       
            matrix[beeRow, beeCol] = 'B';
        }
       
        public static bool IsValid(int size, int row, int col)
        {
            return (row >= 0 && row < size && col >= 0 && col < size);
        }

        public static void Print(char[,] matrix, int size)
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
