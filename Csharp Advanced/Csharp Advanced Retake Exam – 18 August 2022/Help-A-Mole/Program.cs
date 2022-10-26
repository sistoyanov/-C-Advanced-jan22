using System;

namespace Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int molRow = - 1;
            int molCol = - 1;

            int firstSpecialRow = - 1;
            int firstSpecialCol = - 1;
            int secondSpecialRow = - 1;
            int secondSpecialCol = - 1;
            int specilaCount = 0;

            int molPoints = 0;

            for (int row = 0; row < size; row++)
            {
                char[] matrixDetails = Console.ReadLine().ToCharArray();
                
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixDetails[col];
                    
                    if (matrixDetails[col] == 'M')
                    {
                        molRow = row;
                        molCol = col;
                    }
                    else if (matrixDetails[col] == 'S' && specilaCount == 0)
                    {
                        firstSpecialRow = row;
                        firstSpecialCol = col;
                        specilaCount++;
                    }
                    else if (matrixDetails[col] == 'S' && specilaCount > 0)
                    {
                        secondSpecialRow = row;
                        secondSpecialCol = col;
                    }
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End" && molPoints < 25)
            {
                if (input == "up" && molRow - 1 >= 0)
                {
                    matrix[molRow, molCol] = '-';
                    molRow--;

                    if (char.IsDigit(matrix[molRow, molCol]))
                    {
                        molPoints += (matrix[molRow, molCol] - '0');
                    }
                    else if (matrix[molRow, molCol] == 'S')
                    {
                        if (molRow == firstSpecialRow && molCol == firstSpecialCol)
                        {
                            matrix[firstSpecialRow, firstSpecialCol] = '-';
                            molRow = secondSpecialRow;
                            molCol = secondSpecialCol;
                        }
                        else if (molRow == secondSpecialRow && molCol == secondSpecialCol)
                        {
                            matrix[secondSpecialRow, secondSpecialCol] = '-';
                            molRow = firstSpecialRow;
                            molCol = firstSpecialCol;

                        }

                        molPoints -= 3;
                    }

                    matrix[molRow, molCol] = 'M';
                }
                else if (input == "down" && molRow + 1 < size)
                {
                    matrix[molRow, molCol] = '-';
                    molRow++;

                    if (char.IsDigit(matrix[molRow, molCol]))
                    {
                        molPoints += (matrix[molRow, molCol] - '0');
                    }
                    else if (matrix[molRow, molCol] == 'S')
                    {
                        if (molRow == firstSpecialRow && molCol == firstSpecialCol)
                        {
                            matrix[firstSpecialRow, firstSpecialCol] = '-';
                            molRow = secondSpecialRow;
                            molCol = secondSpecialCol;
                        }
                        else if (molRow == secondSpecialRow && molCol == secondSpecialCol)
                        {
                            matrix[secondSpecialRow, secondSpecialCol] = '-';
                            molRow = firstSpecialRow;
                            molCol = firstSpecialCol;
                            
                        }

                        molPoints -= 3;
                    }

                    matrix[molRow, molCol] = 'M';
                }
                else if (input == "left" && molCol - 1 >= 0)
                {
                    matrix[molRow, molCol] = '-';
                    molCol--;

                    if (char.IsDigit(matrix[molRow, molCol]))
                    {
                        molPoints += (matrix[molRow, molCol] - '0');
                    }
                    else if (matrix[molRow, molCol] == 'S')
                    {
                        if (molRow == firstSpecialRow && molCol == firstSpecialCol)
                        {
                            matrix[firstSpecialRow, firstSpecialCol] = '-';
                            molRow = secondSpecialRow;
                            molCol = secondSpecialCol;
                        }
                        else if (molRow == secondSpecialRow && molCol == secondSpecialCol)
                        {
                            matrix[secondSpecialRow, secondSpecialCol] = '-';
                            molRow = firstSpecialRow;
                            molCol = firstSpecialCol;

                        }

                        molPoints -= 3;
                    }

                    matrix[molRow, molCol] = 'M';

                }
                else if (input == "right" && molCol + 1 < size)
                {
                    matrix[molRow, molCol] = '-';
                    molCol++;

                    if (char.IsDigit(matrix[molRow, molCol]))
                    {
                        molPoints += (matrix[molRow, molCol] - '0');
                    }
                    else if (matrix[molRow, molCol] == 'S')
                    {
                        if (molRow == firstSpecialRow && molCol == firstSpecialCol)
                        {
                            matrix[firstSpecialRow, firstSpecialCol] = '-';
                            molRow = secondSpecialRow;
                            molCol = secondSpecialCol;
                        }
                        else if (molRow == secondSpecialRow && molCol == secondSpecialCol)
                        {
                            matrix[secondSpecialRow, secondSpecialCol] = '-';
                            molRow = firstSpecialRow;
                            molCol = firstSpecialCol;

                        }

                        molPoints -= 3;
                    }

                    matrix[molRow, molCol] = 'M';

                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                }
            }

            if (molPoints >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {molPoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {molPoints} points.");
            }

            Print(matrix, size);
        }

        static void Print(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}
