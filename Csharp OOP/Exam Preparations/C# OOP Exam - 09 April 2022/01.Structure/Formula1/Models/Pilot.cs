using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        //bool canRace;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }

        public Pilot()
        {
            //this.canRace = false;
        }

        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }

                this.fullName = value;
            }
        }
        
        public bool CanRace { get; private set; }//=> this.canRace;

        public IFormulaOneCar Car
        {
            get { return this.car; }
            private set 
            {
                if (value is null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }

                this.car = value; 
            }
        }

        public int NumberOfWins { get; private set; }


        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins += 1;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
