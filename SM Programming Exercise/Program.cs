using SM_Programming_Exercise.Library;
using System;

namespace SM_Programming_Exercise
{
    internal class Program
    {
        // Will 0 always be there?
        // Can 0 be in the middle?
        // Can the starting position be off the table (immediate fail?)
        private static void Main(string[] args)
        {
            // Initialise a new simulation
            string tableAndStartPos = "4 , 4, 2, 2";
            string Commands = "1, 4, 1, 3, 2, 3, 2, 4, 1, 2,2,2, 0";

            Simulation simulation = new Simulation(tableAndStartPos, Commands);
            simulation.Run();
            Console.WriteLine(simulation.ResultData);
        }
    }
}