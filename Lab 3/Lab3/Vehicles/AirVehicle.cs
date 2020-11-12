namespace Lab3.Vehicles
{
    internal abstract class AirVehicle : IVehicle
    {
        protected abstract double Speed();
        protected abstract double DistanceReducing(double distance);

        public RaceType Type()
        {
            return RaceType.Air;
        }

        public double Run(Track track)
        {
            return (track.Distance * (1 - DistanceReducing(track.Distance))) / Speed();
        }
    }
}