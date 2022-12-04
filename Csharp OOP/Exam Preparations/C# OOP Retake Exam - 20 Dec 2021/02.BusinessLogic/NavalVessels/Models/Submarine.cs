using NavalVessels.Models.Contracts;
using System;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double SubmarineArmorThickness = 200;
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, SubmarineArmorThickness)
        {
            this.submergeMode = false;
        }

        public bool SubmergeMode => this.submergeMode;

        public void ToggleSubmergeMode()
        {
            if (!this.submergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else if (this.submergeMode)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }

            this.submergeMode = !this.submergeMode;
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = SubmarineArmorThickness;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine} *Submerge mode: {(this.SubmergeMode ? "ON" : "OFF")}";
        }
    }
}
