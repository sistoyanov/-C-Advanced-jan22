using System;

namespace _02._Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            
            int playerRow = 0;
            int playerCol = 0;
            int money = 0;

            int pillarCont = 0;
            int firstPillarRow = 0;
            int firstPillarCol = 0;
            int secondPillarRow = 0;
            int secondPillarCol = 0;


            for (int row = 0; row < size; row++)
            {
                char[] matrixDetails = Console.ReadLine().ToCharArray();
                
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixDetails[col];

                    if (matrix[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (matrix[row, col] == 'O')
                    {
                        if (pillarCont == 0)
                        {
                            firstPillarRow = row;
                            firstPillarCol = col;
                            pillarCont ++;
                        }

                        secondPillarRow = row;
                        secondPillarCol = col;
                    }
                }
            }

            bool isMoneyEnough = false;
            bool isOut = false;

            while (true)
            {
                string currentCommand = Console.ReadLine();

                if (currentCommand == "up")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow--;

                    if (IsValid(playerRow, playerCol, size))
                    {
                        if (IsPillar(ref playerRow, ref playerCol, matrix, firstPillarRow, firstPillarCol, secondPillarRow, secondPillarCol))
                        {
                            matrix[playerRow, playerCol] = 'S';
                        }
                        else
                        {
                            MovePlayer(playerRow, playerCol, matrix, ref money);
                        }
                    }
                    else
                    {
                        isOut = true;
                    }
                }
                else if (currentCommand == "down")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow++;

                    if (IsValid(playerRow, playerCol, size))
                    {
                        if (IsPillar(ref playerRow, ref playerCol, matrix, firstPillarRow, firstPillarCol, secondPillarRow, secondPillarCol))
                        {
                            matrix[playerRow, playerCol] = 'S';
                        }
                        else
                        {
                            MovePlayer(playerRow, playerCol, matrix, ref money);
                        }
                    }
                    else
                    {
                        isOut = true;
                    }
                }
                else if (currentCommand == "left")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol--;

                    if (IsValid(playerRow, playerCol, size))
                    {
                        if (IsPillar(ref playerRow, ref playerCol, matrix, firstPillarRow, firstPillarCol, secondPillarRow, secondPillarCol))
                        {
                            matrix[playerRow, playerCol] = 'S';
                        }
                        else
                        {
                            MovePlayer(playerRow, playerCol, matrix, ref money);
                        }
                    }
                    else
                    {
                        isOut = true;
                    }
                }
                else if (currentCommand == "right")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol++;

                    if (IsValid(playerRow, playerCol, size))
                    {
                        if (IsPillar(ref playerRow, ref playerCol, matrix, firstPillarRow, firstPillarCol, secondPillarRow, secondPillarCol))
                        {
                            matrix[playerRow, playerCol] = 'S';
                        }
                        else
                        {
                            MovePlayer(playerRow, playerCol, matrix, ref money);
                        }
                    }
                    else
                    {
                        isOut = true;
                    }
                }

                if (money >= 50)
                {
                    isMoneyEnough = true;
                    break;
                }

                if (isOut)
                {
                    break;
                }
            }

            if (isOut)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }

            if (isMoneyEnough)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");

            PrintMatrix(matrix, size);
        }

        private static void MovePlayer(int playerRow, int playerCol, char[,] matrix, ref int money)
        {
            if (Char.IsDigit(matrix[playerRow, playerCol]))
            {
                money += int.Parse((matrix[playerRow, playerCol].ToString()));
            }

            matrix[playerRow, playerCol] = 'S';
        }

        private static bool IsPillar(ref int playerRow, ref int playerCol, char[,] matrix, int firstPillarRow, int firstPillarCol, int secondPillarRow, int secondPillarCol)
        {
            if (playerRow == firstPillarRow && playerCol == firstPillarCol)
            {
                playerRow = secondPillarRow;
                playerCol = secondPillarCol;
                matrix[firstPillarRow, firstPillarCol] = '-';
                return true;
            }
            else if (playerRow == secondPillarRow && playerCol == secondPillarCol)
            {
                playerRow = firstPillarRow;
                playerCol = firstPillarCol;
                matrix[secondPillarRow, secondPillarCol] = '-';
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsValid (int playerRow, int playerCol, int size)
        {
            return playerRow >= 0 && playerRow < size && playerCol >= 0 && playerCol < size;
        }

        private static void PrintMatrix(char[,] matrix, int size)
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
