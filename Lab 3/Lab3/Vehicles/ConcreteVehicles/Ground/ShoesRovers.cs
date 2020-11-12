namespace Lab3.Vehicles.ConcreteVehicles
{
    internal class ShoesRovers : GroundVehicle
    {
        protected override double Speed()
        {
            return 6;
        }

        protected override double TimeToRest()
        {
            return 60;
        }
        protected override double RestingTime(int iteration)
        {
            switch (iteration)
            {
                case 1:
                    return 10;
                default:
                    return 5;
            }
        }
    }
}