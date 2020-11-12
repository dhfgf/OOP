namespace Lab3.Vehicles.ConcreteVehicles
{
    internal class Broomstick : AirVehicle
    {
        protected override double Speed()
        {
            return 20;
        }

        protected override double DistanceReducing(double distance)
        {
            return 0.01 * ((int)distance / 1000);
        }
    }
}