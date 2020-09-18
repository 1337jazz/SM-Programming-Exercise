using SM_Programming_Exercise.Library.Enums;
using SM_Programming_Exercise.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM_Programming_Exercise.Library.Data
{
    public class StdinData : IProtocolData
    {
        public int TableWidth { get; set; }
        public int TableHeight { get; set; }
        public int TileStartX { get; set; }
        public int TileStartY { get; set; }
        public IEnumerable<Command> CommandList { get; set; }
        public string firstHeader;
        public string secondHeader;

        public virtual void Read()
        {
            firstHeader = Console.ReadLine();
            secondHeader = Console.ReadLine();

            //int[] arrFirstHeader = ToIntArray(firstHeader);
            //int[] arrSecondHeader = ToIntArray(secondHeader);

            //TableWidth = arrFirstHeader[0];
            //TableHeight = arrFirstHeader[1];
            //TileStartX = arrFirstHeader[2];
            //TileStartY = arrFirstHeader[3];
            //CommandList = TranslateCommands(arrSecondHeader);
        }

        public void Populate()
        {
            int[] arrFirstHeader = ToIntArray(firstHeader);
            int[] arrSecondHeader = ToIntArray(secondHeader);

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
        /// <returns>The original stirng represented as an array of int</returns>
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