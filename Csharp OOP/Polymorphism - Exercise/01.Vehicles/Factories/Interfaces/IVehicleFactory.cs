
namespace Vehicles.Factories.Interfaces
{
    using Models.Interfaces;
    public interface IVehicleFactory
    {
        public IVehicle CreateVehicle(string input);
    }
}
