namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; set;  }

        public double TankCapacity { get;}

        public string Drive(double distance);

        public void Refuel(double fuel);
    }
}
