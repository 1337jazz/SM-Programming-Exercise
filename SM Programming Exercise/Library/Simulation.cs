using SM_Programming_Exercise.Library.Entities;
using SM_Programming_Exercise.Library.Enums;
using System.Collections.Generic;
using System.Linq;

namespace SM_Programming_Exercise.Library
{
    public class Simulation
    {
        public Table Table { get; private set; }
        public Tile Tile { get; private set; }
        public List<Command> Commands { get; private set; } = new List<Command>();
        public string ResultData { get; private set; }

        public bool TileStillOnTable
        {
            get
            {
                if (Tile.X < 0 || Tile.X > Table.Width - 1 ||
                    Tile.Y < 0 || Tile.Y > Table.Height - 1)
                {
                    return false;
                }
                return true;
            }
        }

        public Simulation(string firstHeader, string secondHeader)
        {
            int[] arrFirstHeader = ToIntArray(firstHeader);
            int[] arrSecondHeader = ToIntArray(secondHeader);

            Table = new Table(arrFirstHeader[0], arrFirstHeader[1]);
            Tile = new Tile(arrFirstHeader[2], arrFirstHeader[3]);
            InsertCommands(arrSecondHeader);

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

        private void InsertCommands(int[] arr)
        {
            foreach (int command in arr)
                Commands.Add((Command)command);
        }

        private static int[] ToIntArray(string header)
        {
            return header.Split(',').Select(x => int.Parse(x)).ToArray();
        }
    }
}