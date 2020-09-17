using SM_Programming_Exercise.Library;
using System;

namespace SM_Programming_Exercise
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Initialise a new simulation
            string firstInput = "4 , 4, 2, 2";
            string secondInput = "1, 4, 1, 3, 2, 3, 2, 4, 1, 0";

            Simulation simulation = new Simulation(firstInput, secondInput);
            simulation.Run();
            Console.WriteLine(simulation.ResultData);
        }
    }
}