using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {

            foreach (IAstronaut astronaut in astronauts)
            {
               while (planet.Items.Count > 0 && astronaut.CanBreath)
               {
                   string currentItem = planet.Items.First();
                   astronaut.Breath();
                   astronaut.Bag.Items.Add(currentItem);
                   planet.Items.Remove(currentItem);

               }

                if (planet.Items.Count == 0)
                {
                    break;
                }

            }
            
        }
    }
}
