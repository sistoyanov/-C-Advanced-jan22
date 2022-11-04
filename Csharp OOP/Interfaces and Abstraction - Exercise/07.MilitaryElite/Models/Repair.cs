namespace MilitaryElite.Models
{
    using Interfaces;
    public class Repair : IRepair
    {
        public Repair(string partName, int horsWorked)
        {
            this.PartName = partName;
            this.HoursWorked = horsWorked;
        }
        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
