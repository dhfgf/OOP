namespace Lab3.Vehicles.ConcreteVehicles
{
    internal class Centaur : GroundVehicle
    {
        protected override double Speed()
        {
            return 15;
        }

        protected override double TimeToRest()
        {
            return 8;
        }
        protected override double RestingTime(int iteration)
        {
            return 2;
        }
    }
}