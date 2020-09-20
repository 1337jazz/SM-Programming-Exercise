using SM_Programming_Exercise.Library.Base;
using SM_Programming_Exercise.Library.Enums;
using SM_Programming_Exercise.Library.Interfaces;

namespace SM_Programming_Exercise.Library.Entities
{
    public class Table : GridBase, ICommandable
    {
        public Table(int width, int height) : base(width, height)
        {
        }

        public void ChangeBearing(Rotation rotation)
        {
            return;
        }

        public void Move(Command command)
        {
            return;
        }

        public void ProcessCommand(Command command)
        {
            return;
        }

        // Possibility to override SetGridShape()
        // Possibility to override BoundaryBreached()
    }
}