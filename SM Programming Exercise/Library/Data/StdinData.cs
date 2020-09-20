using SM_Programming_Exercise.Library.Base;
using SM_Programming_Exercise.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM_Programming_Exercise.Library.Data
{
    /// <summary>
    /// Implementation of InputBase to handle stdin
    /// </summary>
    public class StdinData : InputBase
    {
        // Call the base constructor (used for testing)
        public StdinData(bool read = true) : base(read)
        {
        }

        /// <summary>
        /// The main method to read the data, this method is forcibly overriden from the base class
        /// </summary>
        protected override void Read()
        {
            int[] arrFirstHeader = ToIntArray(Console.ReadLine());
            int[] arrSecondHeader = ToIntArray(Console.ReadLine());

            TableWidth = arrFirstHeader[0];
            TableHeight = arrFirstHeader[1];
            TileStartX = arrFirstHeader[2];
            TileStartY = arrFirstHeader[3];
            CommandList = TranslateCommands(arrSecondHeader);
        }

        /// <summary>
        /// Splits a string into an array of int
        /// </summary>
        /// <param name="header">The string to split, assumes comma-seperated list of numbers</param>
        /// <returns>The original string represented as an array of int</returns>
        public static int[] ToIntArray(string header)
            => header.Split(',').Select(x => int.Parse(x)).ToArray();

        /// <summary>
        /// Laziliy yield commands to the command list; performance
        /// is greatly improved when command list is very large
        /// </summary>
        /// <param name="arr">The array from which to translate commands</param>
        /// <returns>Yields an iterable list of Command</returns>
        public IEnumerable<Command> TranslateCommands(int[] arr)
        {
            foreach (int command in arr) yield return (Command)command;
        }
    }
}