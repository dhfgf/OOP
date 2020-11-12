namespace Lab3.Vehicles
{
    internal abstract class GroundVehicle : IVehicle
    {
        protected abstract double Speed();
        protected abstract double TimeToRest();
        protected abstract double RestingTime(int iteration);

        public RaceType Type()
        {
            return RaceType.Ground;
        }

        public double Run(Track track)
        {
            double left_distance = track.Distance;
            double time = 0;
            int iter = 0;
            
            while(true)
            {
                double runned_this_iter = Speed() * TimeToRest();
                iter++;
                
                if (runned_this_iter > left_distance)
                    return time + left_distance / Speed();

                left_distance -= runned_this_iter;
                time += TimeToRest() + RestingTime(iter);
            }
        }
    }
}