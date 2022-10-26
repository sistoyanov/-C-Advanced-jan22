using System;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];
            int collectedTokens = 0;
            int opponentCollectedTokens = 0;

            for (int i = 0; i < rows; i++)
            {
                char[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                beach[i] = tokens;
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] currentCommandDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currentCommand = currentCommandDetails[0];
                int row = int.Parse(currentCommandDetails[1]);
                int col = int.Parse(currentCommandDetails[2]);

                if (IsValid(beach, row, col))
                {
                    if (currentCommand == "Find")
                    {
                        if (beach[row][col] == 'T')
                        {
                            collectedTokens++;
                            beach[row][col] = '-';
                        }
                    }
                    else if (currentCommand == "Opponent")
                    {
                        string direction = currentCommandDetails[3];

                        if (IsValid(beach, row, col))
                        {
                            opponentCollectedTokens++;
                            beach[row][col] = '-';
                        }

                        if (direction == "up")
                        {
                            for (int i = row; i >= row - 3; i--)
                            {

                                if (IsValid(beach, i, col) && beach[i][col] == 'T')
                                {
                                    opponentCollectedTokens++;
                                    beach[i][col] = '-';
                                }

                            }
                        }
                        else if (direction == "down")
                        {
                            for (int i = row; i <= row + 3; i++)
                            {

                                if (IsValid(beach, i, col) && beach[i][col] == 'T')
                                {
                                    opponentCollectedTokens++;
                                    beach[i][col] = '-';
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = col; i >= col - 3; i--)
                            {
                                if (IsValid(beach, row, i) && beach[row][i] == 'T')
                                {
                                    opponentCollectedTokens++;
                                    beach[row][i] = '-';
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = col; i <= 3; i++)
                            {

                                if (IsValid(beach, row, i) && beach[row][i] == 'T')
                                {
                                    opponentCollectedTokens++;
                                    beach[row][i] = '-';
                                }
                            }
                        }
                    }
                }
            }

            Print(beach);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentCollectedTokens}");

        }

        static bool IsValid (char[][] beach, int row, int col)
        {
            return (row >= 0 && row < beach.GetLength(0) && col >= 0 && col < beach[row].Length);
         
        }

        static void Print(char[][] beach)
        {
            for (int row = 0; row < beach.GetLength(0); row++)
            {
                Console.WriteLine(String.Join(" ", beach[row]));
            }
        }
    }
}
