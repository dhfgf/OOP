namespace Lab3.Vehicles.ConcreteVehicles
{
    internal class AirCarpet : AirVehicle
    {
        protected override double Speed()
        {
            return 10;
        }

        protected override double DistanceReducing(double distance)
        {
            if (distance < 1000) return 0;
            if (distance < 5000) return 0.03;
            if (distance < 10000) return 0.1;
            return 0.05;
        }
    }
}