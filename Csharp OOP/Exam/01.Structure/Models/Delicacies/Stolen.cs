﻿namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        private const double DelicacyPrice = 3.50;
        public Stolen(string delicacyName) : base(delicacyName, DelicacyPrice)
        {
        }
    }
}
