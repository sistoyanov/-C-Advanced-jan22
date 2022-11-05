using System.Text;

namespace Animals.Models
{
    internal class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder output = new StringBuilder();
            output
                .AppendLine(base.ExplainSelf())
                .AppendLine("DJAAF");
            return output.ToString().TrimEnd();
        }
    }
}
