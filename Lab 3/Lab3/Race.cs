using System;
using Lab3.Vehicles;

namespace Lab3
{
    internal class Race
    {
        public RaceType Type;
        public Track Track;
        private string Champion;
        private double ChampionTime = -1;

        public Race(RaceType type, Track track)
        {
            Type = type;
            Track = track;
        }

        public void RegisterRunner(IVehicle vehicle)
        {
            if (Type != RaceType.Both && Type != vehicle.Type())
                throw new Exception("Wrong vehicle type");

            if (vehicle.Run(Track) < ChampionTime || ChampionTime == -1)
            {
                ChampionTime = vehicle.Run(Track);
                Champion = vehicle.GetType().ToString().Split('.')[3];
            }
        }

        public string Run()
        {
            return Champion;
        }
    }
}