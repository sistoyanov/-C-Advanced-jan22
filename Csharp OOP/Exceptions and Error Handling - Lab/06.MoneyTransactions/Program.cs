using System;
using System.Collections.Generic;

namespace _06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, decimal> bank = new Dictionary<int, decimal>();
            string[] accountsDetails = Console.ReadLine().Split(",");

            foreach (var account in accountsDetails)
            {
                string[] currentAccountDetails = account.Split('-');
                int accountNumber = int.Parse(currentAccountDetails[0]);
                decimal accountBalance = decimal.Parse(currentAccountDetails[1]);

                if (!bank.ContainsKey(accountNumber))
                {
                    bank.Add(accountNumber, accountBalance);
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArg = input.Split(' ');
                string command = commandArg[0];
                int bankAccount = int.Parse(commandArg[1]);
                decimal money = decimal.Parse(commandArg[2]);

                try
                {
                    if (!bank.ContainsKey(bankAccount))
                    {
                        throw new InvalidAccountException("Invalid account!");
                    }

                    if (command == "Deposit")
                    {
                        bank[bankAccount] += money;
                    }
                    else if (command == "Withdraw")
                    {
                        if (bank[bankAccount] < money)
                        {
                            throw new InsufficientBalanceException("Insufficient balance!");
                        }

                        bank[bankAccount] -= money;
                    }
                    else
                    {
                        throw new InvalidCommandException("Invalid command!");
                    }

                    Console.WriteLine($"Account {bankAccount} has new balance: {bank[bankAccount]:f2}");

                }
                catch (InvalidCommandException ice)
                {
                    Console.WriteLine(ice.Message);
                }
                catch (InvalidAccountException iae)
                {
                    Console.WriteLine(iae.Message);
                }
                catch (InsufficientBalanceException ibe)
                {
                    Console.WriteLine(ibe.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

               
            }
        }

        private class InvalidCommandException : Exception
        {
            public InvalidCommandException()
            {

            }

            public InvalidCommandException(string message) : base(message)
            {

            }
        }

        private class InvalidAccountException : Exception
        {
            public InvalidAccountException()
            {

            }

            public InvalidAccountException(string message) : base(message)
            {

            }
        }

        private class InsufficientBalanceException : Exception
        {
            public InsufficientBalanceException()
            {

            }

            public InsufficientBalanceException(string message) : base(message)
            {

            }
        }
    }
}
