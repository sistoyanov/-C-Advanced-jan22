using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidBunnyType));
            }

            this.bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunny.GetType().Name, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunnyToAddDye = this.bunnies.FindByName(bunnyName);

            if (bunnyToAddDye is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentBunny));
            }

            IDye dyeToAdd = new Dye(power);
            bunnyToAddDye.AddDye(dyeToAdd);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg eggToAdd = new Egg(eggName, energyRequired);
            this.eggs.Add(eggToAdd);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            Workshop workshop = new Workshop();
            ICollection<IBunny> bunniesToColorEgg = this.bunnies.Models.Where(b => b.Energy >= 50).OrderByDescending(b => b.Energy).ToList();

            if (bunniesToColorEgg.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.BunniesNotReady));
            }

            IEgg eggToWorkOn = this.eggs.FindByName(eggName);

            foreach (IBunny bunny in bunniesToColorEgg)
            {
                workshop.Color(eggToWorkOn, bunny);

                if (bunny.Energy == 0)
                {
                    this.bunnies.Remove(bunny);
                }

            }

            if (eggToWorkOn.IsDone())
            {
                return string.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return string.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            int eggsDone = this.eggs.Models.Count(b => b.IsDone());

            output.AppendLine($"{eggsDone} eggs are done!");
            output.AppendLine("Bunnies info:");

            foreach (IBunny bunny in this.bunnies.Models)
            {
                int dyesNotFinished = bunny.Dyes.Count(d => !d.IsFinished());
                
                output.AppendLine($"Name: {bunny.Name}")
                      .AppendLine($"Energy: {bunny.Energy}")
                      .AppendLine($"Dyes: {dyesNotFinished} not finished");
            }

            return output.ToString().TrimEnd();
        }
    }
}
