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
            // Initialise a new Simulation and feed in a concrete implementation of IProtocolData
            // In this case, the data is from stdin ('Console.ReadLine()' in C#), but it is at
            // one could replace 'var data = new StdinData();' with, for example:
            // 'var data = new JsonData();', as long as the JsonData class implemented IProtocolData
            var data = new StdinData();
            data.Read();
            data.Populate();
            Simulation simulation = new Simulation(data);

            // Run the simulation
            simulation.Run();

            // Print the result
            Console.WriteLine(simulation.ResultData);
        }
    }
}