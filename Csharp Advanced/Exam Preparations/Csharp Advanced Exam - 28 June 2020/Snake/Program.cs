using System;
using System.Runtime.CompilerServices;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int snakeRow = 0;
            int snakeCol = 0;

            int bCount = 0;
            int firstBRow = 0;
            int firstBCol = 0;
            int secondBRow = 0;
            int secondBCol = 0;

            int foodEaten = 0;
            bool isOut = false;
            bool isFed = false;

            for (int row = 0; row < size; row++)
            {
                char[] matrixElements = Console.ReadLine().ToCharArray();
                
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixElements[col];

                    if (matrixElements[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (matrixElements[col] == 'B' && bCount == 0)
                    {
                        firstBRow = row;
                        firstBCol = col;
                        bCount++;
                    }
                    else if (matrixElements[col] == 'B' && bCount == 1)
                    {
                        secondBRow = row;
                        secondBCol = col;
                        bCount++;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    snakeRow--;

                    if (IsValid(snakeRow, snakeCol, size))
                    {
  
                        matrix[snakeRow + 1, snakeCol] = '.';

                        if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            int[] changePosition = IsLair(firstBRow, firstBCol, secondBRow, secondBCol, snakeRow, snakeCol);
                            snakeRow = changePosition[0];
                            snakeCol = changePosition[1];
                            matrix[snakeRow, snakeCol] = 'S'; ;
                        }
                        else
                        {
                            MoveSnake(snakeRow, snakeCol, matrix, ref foodEaten);
                        }

                    }
                    else
                    {
                        isOut = true;
                        matrix[snakeRow + 1, snakeCol] = '.';
                        break;
                    }
                }
                else if (command == "down")
                {
                    snakeRow++;

                    if (IsValid(snakeRow, snakeCol, size))
                    {
                        matrix[snakeRow - 1, snakeCol] = '.';

                        if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            int[] changePosition = IsLair(firstBRow, firstBCol, secondBRow, secondBCol, snakeRow, snakeCol);
                            snakeRow = changePosition[0];
                            snakeCol = changePosition[1];
                            matrix[snakeRow, snakeCol] = 'S';
                        }
                        else
                        {
                            MoveSnake(snakeRow, snakeCol, matrix, ref foodEaten);
                        }

                    }
                    else
                    {
                        isOut = true;
                        matrix[snakeRow - 1, snakeCol] = '.';
                        break;
                    }
                }
                else if (command == "left")
                {
                    snakeCol--;

                    if (IsValid(snakeRow, snakeCol, size))
                    {
                        matrix[snakeRow , snakeCol + 1] = '.';

                        if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            int[] changePosition = IsLair(firstBRow, firstBCol, secondBRow, secondBCol, snakeRow, snakeCol);
                            snakeRow = changePosition[0];
                            snakeCol = changePosition[1];
                            matrix[snakeRow, snakeCol] = 'S';
                        }
                        else
                        {
                            MoveSnake(snakeRow, snakeCol, matrix, ref foodEaten);
                        }

                    }
                    else
                    {
                        isOut = true;
                        matrix[snakeRow, snakeCol + 1] = '.';
                        break;
                    }
                }
                else if (command == "right")
                {
                    snakeCol++;

                    if (IsValid(snakeRow, snakeCol, size))
                    {
                        matrix[snakeRow, snakeCol - 1] = '.';

                        if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            int[] changePosition = IsLair(firstBRow, firstBCol, secondBRow, secondBCol, snakeRow, snakeCol);
                            snakeRow = changePosition[0];
                            snakeCol = changePosition[1];
                            matrix[snakeRow, snakeCol] = 'S';
                        }
                        else
                        {
                            MoveSnake(snakeRow, snakeCol, matrix, ref foodEaten);
                        }

                    }
                    else
                    {
                        isOut = true;
                        matrix[snakeRow, snakeCol -  1] = '.';
                        break;
                    }
                }

                if (foodEaten >= 10)
                {
                    isFed = true;
                    break;
                }
            }

            if (isOut)
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Food eaten: {foodEaten}");
            }
            else if (isFed)
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {foodEaten}");
            }

            PrintMatrix(matrix, size);
            
        }

        static bool IsValid(int currentRow, int currenCol, int size)
        {
            if (currentRow >= 0 && currentRow < size && currenCol >= 0 && currenCol < size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void MoveSnake(int moveRow, int moveCol, char[,] matrix, ref int foodEaten)
        {
            
            
            if (matrix[moveRow, moveCol] == '*')
            {
                foodEaten++;

            }

            matrix[moveRow, moveCol] = 'S';
        }

        static int[] IsLair(int firstBRow, int firstBCol, int secondBRow, int secondBCol, int sneakPositionRow, int sneakPositionCol)
        {
            int[] newSnakePosition = new int[2];

            if (sneakPositionRow == firstBRow && sneakPositionCol == firstBCol)
            {
                newSnakePosition[0] = secondBRow;
                newSnakePosition[1] = secondBCol;
            }
            else if (sneakPositionRow == secondBRow && sneakPositionCol == secondBCol)
            {
                newSnakePosition[0] = firstBRow;
                newSnakePosition[1] = firstBCol;
            }

            return newSnakePosition;
        }

        static void PrintMatrix(char[,] matrix, int size)
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
