namespace Lab3.Vehicles.ConcreteVehicles
{
    internal class SpeedCamel : GroundVehicle
    {
        protected override double Speed()
        {
            return 40;
        }

        protected override double TimeToRest()
        {
            return 10;
        }
        protected override double RestingTime(int iteration)
        {
            switch (iteration)
            {
                case 1:
                    return 5;
                case 2:
                    return 6.5;
                default:
                    return 8;
            }
        }
    }
}