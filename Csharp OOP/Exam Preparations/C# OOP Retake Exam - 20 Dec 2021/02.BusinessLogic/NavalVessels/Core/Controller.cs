using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IVessel> vessels;
        private readonly ICollection<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            if (this.captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            else
            {
                Captain newCaptain = new Captain(fullName);
                this.captains.Add(newCaptain);

                return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
            }
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel newVessel = this.vessels.FindByName(name);

            if (newVessel is null)
            {

                if (vesselType == "Submarine")
                {
                    newVessel = new Submarine(name, mainWeaponCaliber, speed);
                    this.vessels.Add(newVessel);
                    return string.Format(OutputMessages.SuccessfullyCreateVessel, newVessel.GetType().Name, name, mainWeaponCaliber, speed);
                }
                else if (vesselType == "Battleship")
                {
                    newVessel = new Battleship(name, mainWeaponCaliber, speed);
                    this.vessels.Add(newVessel);
                    return string.Format(OutputMessages.SuccessfullyCreateVessel, newVessel.GetType().Name, name, mainWeaponCaliber, speed);
                }
                else
                {
                    return OutputMessages.InvalidVesselType;
                }

            }
            else
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, newVessel.GetType().Name, name);
            }

        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captainToAssing = this.captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            IVessel vesselToRecive = this.vessels.FindByName(selectedVesselName);

            if (captainToAssing is null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            else if (vesselToRecive is null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            else if (vesselToRecive.Captain != null) /// verify if this works
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            else
            {
                captainToAssing.AddVessel(vesselToRecive);
                vesselToRecive.Captain = captainToAssing;
                return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
            }
        }

        public string CaptainReport(string captainFullName) => this.captains.First(c => c.FullName == captainFullName).Report();

        public string VesselReport(string vesselName) => this.vessels.FindByName(vesselName).ToString();

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);
            string output = string.Empty;

            if (vessel is null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType().Name == "Battleship")
            {
                (vessel as Battleship).ToggleSonarMode();
                output =  string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else if (vessel.GetType().Name == "Submarine")
            {
                (vessel as Submarine).ToggleSubmergeMode();
                output = string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }

            return output;
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel != null)
            {
                vessel.RepairVessel();
                return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
            }
            else
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = this.vessels.FindByName(attackingVesselName);
            IVessel defendingVessel = this.vessels.FindByName(defendingVesselName);

            if (attackingVessel is null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            else if (defendingVessel is null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            else if (attackingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            else if (defendingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }
            else
            {
                attackingVessel.Attack(defendingVessel);
                return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
            }

        }

    }
}
