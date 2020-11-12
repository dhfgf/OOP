namespace Lab3.Vehicles.ConcreteVehicles
{
    internal class TwoHumpedCamel : GroundVehicle
    {
        protected override double Speed()
        {
            return 10;
        }

        protected override double TimeToRest()
        {
            return 30;
        }
        protected override double RestingTime(int iteration)
        {
            switch (iteration)
            {
                case 1:
                    return 5;
                default:
                    return 8;
            }
        }
    }
}