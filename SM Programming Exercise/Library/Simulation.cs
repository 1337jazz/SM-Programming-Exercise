using SM_Programming_Exercise.Library.Data;
using SM_Programming_Exercise.Library.Entities;
using SM_Programming_Exercise.Library.Enums;
using SM_Programming_Exercise.Library.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SM_Programming_Exercise.Library
{
    public class Simulation
    {
        public Table Table { get; private set; }
        public Tile Tile { get; private set; }
        public IEnumerable<Command> Commands { get; private set; }
        public string ResultData { get; private set; }

        public bool TileStillOnTable { get => Table.BoundaryBreached(Tile.X, Tile.Y) ? false : true; }

        public Simulation(IProtocolData data)
        {
            Table = new Table(data.TableWidth, data.TableHeight);
            Tile = new Tile(data.TileStartX, data.TileStartY);
            Commands = data.CommandList;
            ResultData = $"{Tile.X}, {Tile.Y}";
        }

        public Simulation(string firstHeader, string secondHeader)
        {
            int[] arrFirstHeader = ToIntArray(firstHeader);
            int[] arrSecondHeader = ToIntArray(secondHeader);

            Table = new Table(arrFirstHeader[0], arrFirstHeader[1]);
            Tile = new Tile(arrFirstHeader[2], arrFirstHeader[3]);
            Commands = TranslateCommands(arrSecondHeader);

            ResultData = $"{Tile.X}, {Tile.Y}";
        }

        public void Run()
        {
            // Check if the tile starts off the table and immediately fail.
            if (!TileStillOnTable)
            {
                ResultData = "-1, -1";
                return;
            }

            foreach (Command command in Commands)
            {
                if (command == Command.Quit)
                    break;

                if (TileStillOnTable)
                {
                    Tile.ProcessCommand(command);
                    ResultData = $"{Tile.X}, {Tile.Y}";
                }
                else
                {
                    ResultData = "-1, -1";
                    break;
                }
            }
        }

        /// <summary>
        /// Laziliy yield commands to the command list; performance
        /// is greatly improved when command list is very large
        /// </summary>
        /// <param name="arr">The array from which to translate commands</param>
        /// <returns>Yields an iterable list of Command</returns>
        private IEnumerable<Command> TranslateCommands(int[] arr)
        {
            foreach (int command in arr) yield return (Command)command;
        }

        /// <summary>
        /// Splits a string into an array of int
        /// </summary>
        /// <param name="header">The string to split, assumes comma-seperated list of numbers</param>
        /// <returns>The original stirng represented as an array of int</returns>
        private static int[] ToIntArray(string header)
            => header.Split(',').Select(x => int.Parse(x)).ToArray();
    }
}