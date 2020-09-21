using SM_Programming_Exercise.Library.Entities;
using SM_Programming_Exercise.Library.Enums;
using SM_Programming_Exercise.Library.Interfaces;
using System.Collections.Generic;

namespace SM_Programming_Exercise.Library
{
    /// <summary>
    /// Represents a Simulation and exposes relevant methods
    /// </summary>
    public class Simulation
    {
        public Table Table { get; private set; }
        public Tile Tile { get; private set; }
        public IEnumerable<Command> Commands { get; private set; }
        public string ResultData { get; private set; }

        public bool TileStillOnTable { get => Table.BoundaryBreached(Tile.X, Tile.Y) ? false : true; }

        public Simulation(IData data)
        {
            Table = new Table(data.TableWidth, data.TableHeight);
            Tile = new Tile(data.TileStartX, data.TileStartY);
            Commands = data.CommandList;
            ResultData = $"{Tile.X}, {Tile.Y}";
        }

        /// <summary>
        /// Runs the simulation
        /// </summary>
        public void Run()
        {
            ExecuteTileCommands();
            // ExecuteTableCommands() could go here
        }

        /// <summary>
        /// Executes commands pertaining to the Tile object
        /// </summary>
        private void ExecuteTileCommands()
        {
            // Check if the tile starting position is already
            // off the table, and immediately fail.
            if (!TileStillOnTable)
            {
                ResultData = "-1, -1";
                return;
            }

            // Process each command in turn, and update the result data with the new position of
            // the tile
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
    }
}