using System;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int officerRow = 0;
            int officerCol = 0;

            int mirrorCount = 0;
            int mirror1Row = 0;
            int mirror1Col = 0;
            int mirror2Row = 0;
            int mirror2Col = 0;

            int collecteGold = 0;

            for (int row = 0; row < size; row++)
            {
                char[] matrixDetails = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixDetails[col];

                    if (matrixDetails[col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                    else if (matrixDetails[col] == 'M' && mirrorCount == 0)
                    {
                        mirror1Row = row;
                        mirror1Col = col;
                        mirrorCount++;
                    }
                    else if (matrixDetails[col] == 'M' && mirrorCount > 0)
                    {
                        mirror2Row = row;
                        mirror2Col = col;
                    }
                }
            }

            while (true)
            {
                string currentCommand = Console.ReadLine();

                if (currentCommand == "up" && IsValid(officerRow - 1, officerCol, size))
                {
                    matrix[officerRow, officerCol] = '-';
                    officerRow--;

                    if (officerRow == mirror1Row && officerCol == mirror1Col)
                    {
                        officerRow = mirror2Row;
                        officerCol = mirror2Col;
                        matrix[mirror1Row, mirror1Col] = '-';
                        matrix[mirror2Row, mirror2Col] = 'A';
                        continue;
                    }
                    else if (officerRow == mirror2Row && officerCol == mirror2Col)
                    {
                        officerRow = mirror1Row;
                        officerCol = mirror1Col;
                        matrix[mirror2Row, mirror2Col] = '-';
                        matrix[mirror1Row, mirror1Col] = 'A';
                        continue;
                    }


                    if (char.IsDigit(matrix[officerRow, officerCol]))
                    {
                        collecteGold += (matrix[officerRow, officerCol] - '0');
                        matrix[officerRow, officerCol] = 'A';
                    }

                    if (collecteGold >= 65)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        break;
                    }

                }
                else if (currentCommand == "down" && IsValid(officerRow + 1, officerCol, size))
                {
                    
                    matrix[officerRow, officerCol] = '-';
                    officerRow++;

                    if (officerRow == mirror1Row && officerCol == mirror1Col)
                    {
                        officerRow = mirror2Row;
                        officerCol = mirror2Col;
                        matrix[mirror1Row, mirror1Col] = '-';
                        matrix[mirror2Row, mirror2Col] = 'A';
                        continue;
                    }
                    else if (officerRow == mirror2Row && officerCol == mirror2Col)
                    {
                        officerRow = mirror1Row;
                        officerCol = mirror1Col;
                        matrix[mirror2Row, mirror2Col] = '-';
                        matrix[mirror1Row, mirror1Col] = 'A';
                        continue;
                    }

                    if (char.IsDigit(matrix[officerRow, officerCol]))
                    {
                        collecteGold += (matrix[officerRow, officerCol] - '0');
                        matrix[officerRow, officerCol] = 'A';
                    }

                    if (collecteGold >= 65)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        break;
                    }
                }
                else if (currentCommand == "left" && IsValid(officerRow, officerCol - 1, size))
                {
                    
                    matrix[officerRow, officerCol] = '-';
                    officerCol--;

                    if (officerRow == mirror1Row && officerCol == mirror1Col)
                    {
                        officerRow = mirror2Row;
                        officerCol = mirror2Col;
                        matrix[mirror1Row, mirror1Col] = '-';
                        matrix[mirror2Row, mirror2Col] = 'A';
                        continue;
                    }
                    else if (officerRow == mirror2Row && officerCol == mirror2Col)
                    {
                        officerRow = mirror1Row;
                        officerCol = mirror1Col;
                        matrix[mirror2Row, mirror2Col] = '-';
                        matrix[mirror1Row, mirror1Col] = 'A';
                        continue;
                    }

                    if (char.IsDigit(matrix[officerRow, officerCol]))
                    {
                        collecteGold += (matrix[officerRow, officerCol] - '0');
                        matrix[officerRow, officerCol] = 'A';
                    }

                    if (collecteGold >= 65)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        break;
                    }
                }
                else if (currentCommand == "right" && IsValid(officerRow, officerCol + 1, size))
                {
                    
                    matrix[officerRow, officerCol] = '-';
                    officerCol++;

                    if (officerRow == mirror1Row && officerCol == mirror1Col)
                    {
                        officerRow = mirror2Row;
                        officerCol = mirror2Col;
                        matrix[mirror1Row, mirror1Col] = '-';
                        matrix[mirror2Row, mirror2Col] = 'A';
                        continue;
                    }
                    else if (officerRow == mirror2Row && officerCol == mirror2Col)
                    {
                        officerRow = mirror1Row;
                        officerCol = mirror1Col;
                        matrix[mirror2Row, mirror2Col] = '-';
                        matrix[mirror1Row, mirror1Col] = 'A';
                        continue;
                    }

                    if (char.IsDigit(matrix[officerRow, officerCol]))
                    {
                        collecteGold += (matrix[officerRow, officerCol] - '0');
                        matrix[officerRow, officerCol] = 'A';
                    }

                    if (collecteGold >= 65)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("I do not need more swords!");
                    matrix[officerRow, officerCol] = '-';
                    break;
                }
                
            }

            Console.WriteLine($"The king paid {collecteGold} gold coins.");
            Print(matrix, size);
        }

        private static bool IsValid(int row, int col, int size) => (row >= 0 && row < size && col >= 0 && col < size);

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
