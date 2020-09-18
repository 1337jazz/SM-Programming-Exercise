using SM_Programming_Exercise.Library;
using System;

namespace SM_Programming_Exercise
{
    internal class Program
    {
        /// <summary>
        /// Entry point to the application
        /// </summary>
        /// <param name="args"></param>
        private static void Main()
        {
            // Initialise a new simulation
            Simulation simulation = new Simulation(Console.ReadLine(), Console.ReadLine());

            // Run the simulation
            simulation.Run();

            // Print the result
            Console.WriteLine(simulation.ResultData);
        }
    }
}