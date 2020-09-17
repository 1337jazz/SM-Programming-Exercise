using SM_Programming_Exercise.Library.Enums;

namespace SM_Programming_Exercise.Library
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Bearing Bearing { get; set; } = Bearing.North;

        public Tile(int startX, int startY)
        {
            // Initialise the starting position of the tile
            X = startX;
            Y = startY;
        }

        public void Move(Command command)
        {
            switch (command)
            {
                case Command.Quit:
                    break;

                case Command.MoveForward:
                    System.Console.WriteLine("Move forward");
                    break;

                case Command.MoveBackwards:
                    System.Console.WriteLine("Move backwards");
                    break;

                case Command.RotateClockwise:
                    System.Console.WriteLine($"Change bearing clockwise");
                    ChangeBearing(Rotation.Clockwise);
                    System.Console.WriteLine($"New bearing: {Bearing}");
                    break;

                case Command.RotateAntiClockwise:
                    System.Console.WriteLine($"Change bearing Anticlockwise");
                    ChangeBearing(Rotation.Anticlockwise);
                    System.Console.WriteLine($"New bearing: {Bearing}");
                    break;

                default:
                    // TODO: Throw a proper exception
                    throw new System.Exception();
            }
        }

        private void ChangeBearing(Rotation rotation)
        {
            switch (rotation)
            {
                case Rotation.Clockwise:
                    Bearing = Bearing == Bearing.West ? Bearing.North : Bearing += 1;
                    break;

                case Rotation.Anticlockwise:
                    Bearing = Bearing == Bearing.North ? Bearing.West : Bearing -= 1;
                    break;

                default:
                    // TODO: Throw a proper exception
                    throw new System.Exception();
            }
        }
    }
}