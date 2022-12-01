﻿namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int SleepyBunnyEnergy = 50;
        public SleepyBunny(string name) : base(name, SleepyBunnyEnergy)
        {
        }

        public override void Work()
        {
            this.Energy -= 15;

            //if (this.Energy < 0)
            //{
            //    this.Energy = 0;
            //}
        }
    }
}
