using System;

namespace B20_Ex03_Dor_313426975_Sagiv_203516794
{
    public class Program
    {
        public static void Main()
        {
            SystemManager manager = new SystemManager();

            manager.OpenGarage();

            Console.WriteLine("Garage Was Destroyed press ENTER to finish");
            Console.ReadLine();
        }
    }
}
