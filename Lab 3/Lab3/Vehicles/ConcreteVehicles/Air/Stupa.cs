namespace Lab3.Vehicles.ConcreteVehicles
{
    internal class Stupa : AirVehicle
    {
        protected override double Speed()
        {
            return 8;
        }

        protected override double DistanceReducing(double distance)
        {
            return 0.06;
        }
    }
}