using NavalVessels.Models.Contracts;
using System;
using System.Runtime.CompilerServices;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double BattleshipArmorThickness = 300;
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, BattleshipArmorThickness)
        {
            this.sonarMode = false;
        }

        public bool SonarMode => this.sonarMode;

        public void ToggleSonarMode()
        {
            if (!this.sonarMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else if (this.sonarMode)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }

            this.sonarMode = !this.sonarMode;
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = BattleshipArmorThickness;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}*Sonar mode: {(this.SonarMode ? "ON" : "OFF")}";
        }

    }
}
