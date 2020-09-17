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
        public string ResultData { get; set; }

        private char[] trimChars = new char[] { ',', ' ' };

        public Simulation(string firstHeader, string secondHeader)
        {
            int[] arrFirstHeader = ToIntArray(firstHeader);
            int[] arrSecondHeader = ToIntArray(secondHeader);

            Table = new Table(arrFirstHeader[0], arrFirstHeader[1]);
            Tile = new Tile(arrFirstHeader[2], arrFirstHeader[3]);
            InsertCommands(arrSecondHeader);
        }

        public void Run()
        {
            foreach (Command command in Commands)
                Tile.Move(command);
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