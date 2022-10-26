using System;
using System.Drawing;
using System.Linq;

namespace _09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] symblos = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                
                for (int col = 0; col < size; col++)
                {
                    matrix[row,col] = symblos[col];
                }
            }

            int tottalCoalCount = CountCoal(matrix);

            int[] startingPoint = FindStaringPoint(matrix, size);
            int startingPointRow = startingPoint[0];
            int startingPointCol = startingPoint[1];

            int currentPositionRow = startingPointRow;
            int currentPositionCol = startingPointCol;

            bool isOver = false;

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];
                

                if (IsValidCommand(size, currentCommand, currentPositionRow, currentPositionCol) && currentCommand == "up") //Up
                {
                    if (matrix[currentPositionRow - 1, currentPositionCol] == 'c')
                    {
                        tottalCoalCount--;
                        matrix[currentPositionRow - 1, currentPositionCol] = '*';
                        
                    }
                    else if (matrix[currentPositionRow - 1, currentPositionCol] == 'e')
                    {
                        isOver = true;
                    }

                    currentPositionRow -= 1;
                }
                else if (IsValidCommand(size, currentCommand, currentPositionRow, currentPositionCol) && currentCommand == "down") //Down
                {
                    if (matrix[currentPositionRow + 1, currentPositionCol] == 'c')
                    {
                        tottalCoalCount --;
                        matrix[currentPositionRow + 1, currentPositionCol] = '*';
                    }
                    else if (matrix[currentPositionRow + 1, currentPositionCol] == 'e')
                    {
                        isOver = true;
                    }

                    currentPositionRow += 1;
                }
                else if (IsValidCommand(size, currentCommand, currentPositionRow, currentPositionCol) && currentCommand == "right") //Right
                {
                    if (matrix[currentPositionRow , currentPositionCol + 1] == 'c')
                    {
                        tottalCoalCount--;
                        matrix[currentPositionRow, currentPositionCol + 1] = '*';
                    }
                    else if (matrix[currentPositionRow , currentPositionCol + 1] == 'e')
                    {
                        isOver = true;
                    }

                    currentPositionCol += 1;
                }
                else if (IsValidCommand(size, currentCommand, currentPositionRow, currentPositionCol) && currentCommand == "left") //Left
                {
                    if (matrix[currentPositionRow, currentPositionCol - 1] == 'c')
                    {
                        tottalCoalCount--;
                        matrix[currentPositionRow, currentPositionCol - 1] = '*';
                    }
                    else if (matrix[currentPositionRow, currentPositionCol - 1] == 'e')
                    {
                        isOver = true;
                    }

                    currentPositionCol -= 1;
                }

                if (isOver)
                {
                    Console.WriteLine($"Game over! ({currentPositionRow}, {currentPositionCol})");
                    return;
                }

                if (tottalCoalCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({currentPositionRow}, {currentPositionCol})");
                    return;
                }

            }

            Console.WriteLine($"{tottalCoalCount} coals left. ({currentPositionRow}, {currentPositionCol})");
        }

        static int CountCoal(char[,] matrix)
        {
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == 'c')
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        static bool IsValidCommand(int size, string currentCommand, int currentPositionRow, int currentPositionCol)
        {
            if (currentCommand == "up" && currentPositionRow - 1 >= 0) //up
            {
                return true;
            }
            else if (currentCommand == "down" && currentPositionRow + 1 < size) // down
            {
                return true;
            }
            else if (currentCommand == "left" && currentPositionCol - 1 >= 0) // left
            {
                return true;
            }
            else if (currentCommand == "right" && currentPositionCol + 1 < size) // right
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int[] FindStaringPoint(char[,] matrix, int size)
        {
            int[] currentPosition = new int[2]; 
            
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row,col] == 's')
                    {
                        currentPosition[0] = row;
                        currentPosition[1] = col;
                    }
                }
            }

            return currentPosition;
        }
    }
}
