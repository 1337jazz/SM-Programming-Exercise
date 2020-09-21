using SM_Programming_Exercise.Library.Enums;
using SM_Programming_Exercise.Library.Interfaces;
using System;

namespace SM_Programming_Exercise.Library.Entities
{
    /// <summary>
    /// Implements ICommandable; commands can be sent to this object
    /// </summary>
    public class Tile : ICommandable
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Bearing Bearing { get; private set; }

        public Tile(int startX, int startY)
        {
            // Initialise the starting position and bearing of the tile
            X = startX;
            Y = startY;
            Bearing = Bearing.North;
        }

        /// <summary>
        /// Processes a command, does nothing if the command is invalid
        /// </summary>
        /// <param name="command"></param>
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

        /// <summary>
        /// Changes the direction of the ICommandable object
        /// </summary>
        /// <param name="rotation">The new direction in which the tile should face</param>
        public void ChangeBearing(Rotation rotation)
        {
            Bearing = rotation switch
            {
                Rotation.Clockwise => Bearing == Bearing.West ? Bearing.North : Bearing += 1,
                Rotation.Anticlockwise => Bearing == Bearing.North ? Bearing.West : Bearing -= 1,
                _ => throw new Exception("Invalid bearing!"),
            };
        }

        /// <summary>
        /// Moves the ICommandable object by one. An overload could perhaps increase the distance
        /// travelled. Does nothing if the command is invalid
        /// </summary>
        /// <param name="command">The command to process</param>
        public void Move(Command command)
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
                    break;
            }
        }
    }
}