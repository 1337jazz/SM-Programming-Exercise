using SM_Programming_Exercise.Library.Enums;

namespace SM_Programming_Exercise.Library.Entities
{
    public class Tile
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Bearing Bearing { get; private set; }

        public Tile(int startX, int startY)
        {
            // Initialise the starting position of the tile
            X = startX;
            Y = startY;
            Bearing = Bearing.North;
        }

        public void ProcessCommand(Command command)
        {
            switch (command)
            {
                case Command.Quit: break;
                case Command.MoveForward: Move(command); break;
                case Command.MoveBackwards: Move(command); break;
                case Command.RotateClockwise: ChangeBearing(Rotation.Clockwise); break;
                case Command.RotateAntiClockwise: ChangeBearing(Rotation.Anticlockwise); break;
                default: break;
            }
        }

        private void ChangeBearing(Rotation rotation)
        {
            Bearing = rotation switch
            {
                Rotation.Clockwise => Bearing == Bearing.West ? Bearing.North : Bearing += 1,
                Rotation.Anticlockwise => Bearing == Bearing.North ? Bearing.West : Bearing -= 1,
                _ => throw new System.Exception(),// TODO: Throw a proper exception
            };
        }

        private void Move(Command command)
        {
            int directionalOffset = command == Command.MoveForward ? 1 : -1;
            switch (Bearing)
            {
                case Bearing.North:
                    Y -= directionalOffset;
                    break;

                case Bearing.East:
                    X += directionalOffset;
                    break;

                case Bearing.South:
                    Y += directionalOffset;
                    break;

                case Bearing.West:
                    X -= directionalOffset;
                    break;

                default:
                    // TODO: Throw a proper exception
                    throw new System.Exception();
            }
        }
    }
}