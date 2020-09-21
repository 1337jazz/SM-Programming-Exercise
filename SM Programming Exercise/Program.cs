using SM_Programming_Exercise.Library;
using SM_Programming_Exercise.Library.Data;
using System;

namespace SM_Programming_Exercise
{
    internal class Program
    {
        /// <summary>
        /// Entry point to the application
        /// </summary>
        private static void Main()
        {
            // Select the type of data, which should be an implementation of IData
            var data = new StdinData();
            // var data = new JsonData(); <-- or uncomment this for JSON

            // Initialise a new Simulation and feed in a concrete implementation of IData
            Simulation simulation = new Simulation(data);

            // Run the simulation
            simulation.Run();

            // Print the result
            Console.WriteLine(simulation.ResultData);
            Console.ReadLine();
        }
    }
}