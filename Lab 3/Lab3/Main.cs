using System;
using Lab3.Vehicles.ConcreteVehicles;

namespace Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                
                Track track = new Track(1000);
                Race race = new Race(RaceType.Both, track);

                race.RegisterRunner(new AirCarpet());
                race.RegisterRunner(new Broomstick());
                race.RegisterRunner(new Stupa());
                race.RegisterRunner(new Centaur());
                race.RegisterRunner(new ShoesRovers());
                race.RegisterRunner(new SpeedCamel());
                race.RegisterRunner(new TwoHumpedCamel());

                Console.WriteLine($"{race.Run()} is a champion");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}