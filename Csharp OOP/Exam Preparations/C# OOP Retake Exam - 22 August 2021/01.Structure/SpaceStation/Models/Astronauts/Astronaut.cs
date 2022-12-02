﻿using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                this.name = value; 
            }

        }

        public double Oxygen
        {
            get { return this.oxygen; }
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value; 
            }
        }

        public bool CanBreath { get; private set; }

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            this.Oxygen -= 10;

            if (this.Oxygen < 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
