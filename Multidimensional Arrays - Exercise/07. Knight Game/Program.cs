using System;
using System.Security.Cryptography;

namespace _07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];

            for (int row = 0; row < size; row++)
            {
                string elements = Console.ReadLine();
                
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col].ToString();
                }
            }

            int kRemoved = 0;

            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            while (true)
            {
                int mostAttacking = 0;
                int mostAttackingRow = 0;
                int mostAttackingCol = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {

                        if (matrix[row, col] == "K")
                        {
                            int attackedKnights = ContAttacked(matrix, row, col, size);

                            if (attackedKnights > mostAttacking)
                            {
                                mostAttacking = attackedKnights;
                                mostAttackingRow = row;
                                mostAttackingCol = col;

                            }
                        }
                    }
                }


                if (mostAttacking == 0)
                {
                    break;
                }
                else
                {
                    matrix[mostAttackingRow, mostAttackingCol] = "0";
                    kRemoved++;
                }
            }

            Console.WriteLine(kRemoved);
        }

        static int ContAttacked(string[,] matrix, int row, int col, int size)
        {
            int currentAttacking = 0;
            
            if (iSValid(row - 2, col + 1, size)) //Up&Right
            {
                if (matrix[row - 2, col + 1] == "K")
                {
                    currentAttacking++;
                }
            }
            
            if (iSValid(row - 2, col - 1, size)) //Up&Left
            {
                if (matrix[row - 2, col - 1] == "K")
                {
                    currentAttacking++;
                }
            }
            
            if (iSValid(row + 2, col + 1, size)) //Down&Right
            {
                if (matrix[row + 2, col + 1] == "K")
                {
                    currentAttacking++;
                }
            }
            
            if (iSValid(row + 2, col - 1, size)) //Down&Left
            {
                if (matrix[row + 2, col - 1] == "K")
                {
                    currentAttacking++;
                }
            }
            
            if (iSValid(row - 1, col + 2, size)) //Right&Up
            {
                if (matrix[row - 1, col + 2] == "K")
                {
                    currentAttacking++;
                }
            }
            
            if (iSValid(row + 1, col + 2, size)) //Right&Down
            {
                if (matrix[row + 1, col + 2] == "K")
                {
                    currentAttacking++;
                }
            }
            
            if (iSValid(row - 1, col - 2, size)) //Leftt&Up
            {
                if (matrix[row - 1, col - 2] == "K")
                {
                    currentAttacking++;
                }
            }
            
            if (iSValid(row + 1, col - 2, size)) //Left&Down
            {
                if (matrix[row + 1, col - 2] == "K")
                {
                    currentAttacking++;
                }
            }

            return currentAttacking;
        }

        static bool iSValid(int row, int col, int size)
        {
            if (row >=0 && row < size && col >=0 && col < size)
            {
                return true;
            }

            return false;
        }
    }
}
