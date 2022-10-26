using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();

            int carPassedCount = 0;
            bool isCrashed = false;
            string crashedCar = string.Empty;
            char crashedCarPart = ' ';
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string currentCommand = input;
                int greenLight = greenLightDuration;
                int passSeconds = freeWindowDuration;

                if (currentCommand != "green")
                {
                    carsQueue.Enqueue(currentCommand);
                }
                else
                {
                    while (greenLight > 0 && carsQueue.Count > 0)
                    {
                        string currentCar = carsQueue.Dequeue();
                        greenLight -= currentCar.Count();

                        if (greenLight >= 0)
                        {
                            carPassedCount++;
                        }
                        else
                        {
                            passSeconds += greenLight;

                            if (passSeconds >= 0)
                            {
                                carPassedCount++;
                            }
                            else
                            {
                                isCrashed = true;
                                crashedCar = currentCar;
                                crashedCarPart = currentCar[currentCar.Length + passSeconds];
                                break;

                            }
                        }
                    }
                }

                if (isCrashed)
                {
                    break;
                }

            }

            if (isCrashed)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCar} was hit at {crashedCarPart}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carPassedCount} total cars passed the crossroads.");
            }
        }
    }
}
