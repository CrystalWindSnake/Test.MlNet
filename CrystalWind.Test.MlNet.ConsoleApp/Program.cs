using CrystalWind.Test.MlNet.ConsoleApp.Trainers;
using System;

namespace CrystalWind.Test.MlNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new Runner();
            runner.Run();
            
            Console.Read();

        }
    }
}
