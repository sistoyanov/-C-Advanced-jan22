namespace MilitaryElite.Models
{
    using Interfaces;
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LatName = lastName;
        }
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LatName { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LatName} Id: {this.Id} ";
        }
    }
}
