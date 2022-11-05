using System.Text;

namespace Animals.Models
{
    internal class Cat : Animal
    {
        public Cat(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder output = new StringBuilder();
            output
                .AppendLine(base.ExplainSelf())
                .AppendLine("MEEOW");
            return output.ToString().TrimEnd();
        }
    }
}
