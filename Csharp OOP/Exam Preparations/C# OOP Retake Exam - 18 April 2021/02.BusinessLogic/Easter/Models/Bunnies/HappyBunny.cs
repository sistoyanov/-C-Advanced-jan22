namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int BunnyEnergy = 100;
        public HappyBunny(string name) : base(name, BunnyEnergy)
        {
        }

        public override void Work()
        {
            this.Energy -= 10;
        }
    }
}
