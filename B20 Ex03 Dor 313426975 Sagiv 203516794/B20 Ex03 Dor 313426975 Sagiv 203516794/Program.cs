using System;

namespace Ex03.ConsoleUI
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
