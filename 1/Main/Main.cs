using System;


using Lab1.Exceptions;

namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var ini = new IniFile();
                ini.Parse($"C:/Users/777/RiderProjects/Lab1/Lab1/Samples/Sample.ini");
                
                var str = ini.getString("COMMON", "DiscCatchePart");
                var igr = ini.getInt("COMMON", "LogNCMD");
                var dbl = ini.getDouble("ADC_DEV", "BufferLenSeconds");
                Console.WriteLine($"{str}; {igr}; {dbl}; all correct");
            }
            catch (MainException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}