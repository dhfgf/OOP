namespace Lab3.Vehicles
{
    internal interface IVehicle
    {
        RaceType Type();
        double Run(Track track);
    }
}